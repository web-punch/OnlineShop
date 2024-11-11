using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Models;
using OnlineShopWebApp.ReviewsApi.Models;
using System.Net;

namespace OnlineShopWebApp.ReviewsApi
{
    public class ReviewApiClient
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly UserManager<User> userManager;

        public ReviewApiClient(IHttpClientFactory httpClientFactory, UserManager<User> userManager)
        {
            this.httpClientFactory = httpClientFactory;
            this.userManager = userManager;
        }

        private HttpClient CreateHttpClientForReviewsApi()
        {
            return httpClientFactory.CreateClient("ReviewsApi");
        }

        public async Task<List<Review>> GetReviewsAsync(Guid productId)
        {
            var httpClient = CreateHttpClientForReviewsApi();
            var reviews = await httpClient.GetFromJsonAsync<List<Review>>($"/Review/GetReviewsByProductId?productId={productId}");
            return reviews;
        }
        public async Task AddReviewAsync(AddReview model)
        {
            var user = await userManager.FindByIdAsync(model.UserId.ToString());
            if (user != null)
            {
                var existingToken = await userManager.GetAuthenticationTokenAsync(user, "ReviewsApi", "AuthToken");
                if (existingToken != null)
                {
                    var httpClient = CreateHttpClientForReviewsApi();
                    httpClient.DefaultRequestHeaders.Add("accept", "text/plain");
                    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {existingToken}");
                    await httpClient.PostAsJsonAsync("/Review/AddReview", model);
                }
            }
        }
        public async Task<bool> CheckLoginAsync(string userName)
        {
            var httpClient = CreateHttpClientForReviewsApi();
            var result = await httpClient.GetAsync($"/Authentication/CheckLogin?userName={userName}");
            return result.StatusCode == HttpStatusCode.OK;
        }
        public async Task AddLoginAsync(LoginReview loginReview)
        {
            var httpClient = CreateHttpClientForReviewsApi();
            await httpClient.PostAsJsonAsync("/Authentication/Addlogin", loginReview);
        }
        public async Task<string> LoginAsync(LoginReview loginReview)
        {
            var httpClient = CreateHttpClientForReviewsApi();
            var request = await httpClient.PostAsJsonAsync("/Authentication/Login", loginReview);
            var response = await request.Content.ReadFromJsonAsync<TokenResponse>();
            return response?.Token ?? string.Empty;
        }
        public async Task InitializerAsync()
        {
            var adminName = "admin@gmail.com";
            if (!await CheckLoginAsync(adminName))
            {
                var user = await userManager.FindByNameAsync(adminName);
                if (user != null)
                {
                    var loginReview = new LoginReview()
                    {
                        UserName = user.UserName!,
                        Password = user.PasswordHash!
                    };
                    await AddLoginAsync(loginReview);
                }
            }
        }
    }
}
