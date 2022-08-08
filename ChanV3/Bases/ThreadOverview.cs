using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Models.Chan;
using Models.Downloads;
using Services.Interfaces;
using System.Web;

namespace ChanV3.Pages
{
    public partial class ThreadOverview
    {
        [Parameter]
        public string BoardId { get; set; }

        [Parameter]
        public string ThreadId { get; set; }
        [Parameter]
        public string ThreadTitle { get; set; }

        private string _thumbnailPlaceHolderId { get; set; }

        [Inject]
        private IThreadService ThreadService { get; set; }
        [Inject]
        private Microsoft.JSInterop.IJSRuntime jSRuntime { get; set; }
        [Inject]
        private IGeneralConfigService GeneralConfigService { get; set; }
        [Inject]
        private IPostService PostService { get; set; }

        private DownloadManager downloadManager;

        private Posts Posts { get; set; }

        private string DisplayTitle { get; set; }

        private IJSObjectReference threadOverviewJs;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                // import the script from the file
                threadOverviewJs = await jSRuntime.InvokeAsync<IJSObjectReference>("import", "/Pages/ThreadOverview.razor.js");
            }
        }

        protected override async Task OnParametersSetAsync()
        {
            if(!string.IsNullOrEmpty(BoardId) && !string.IsNullOrEmpty(ThreadId))
            {
                if(int.TryParse(ThreadId, out var threadNumber))
                {
                    Posts = await ThreadService.GetPostsInThreads(BoardId, threadNumber);
                }
            }
            DisplayTitle = string.IsNullOrEmpty(ThreadTitle) ? ThreadId : HttpUtility.UrlDecode(ThreadTitle);
        }

        private async Task<Stream> GetImageStreamAsync(string imageId) => await PostService.GetImageThumbnailAsync(BoardId, imageId);

        private async Task SetImageUsingStreamingAsync(string imageId, string thumbnailPlaceHolderId)
        {
            _thumbnailPlaceHolderId = thumbnailPlaceHolderId;
            var imageStream = await GetImageStreamAsync(imageId);
            var dotnetImageStream = new DotNetStreamReference(imageStream);
            await threadOverviewJs.InvokeVoidAsync("setImageUsingStreaming", thumbnailPlaceHolderId, dotnetImageStream);
        }

        protected int ConvertBytesToKiloBytes(int bytes) => bytes / 1024;

        private void SelectAllPosts(object isChecked)
        {
            foreach(var post in Posts.PostCollection.ToList())
            {
                if(post.fsize > 1)
                {
                    post.Checked = (bool)isChecked;
                }
            }
        }

        protected async Task DownloadFiles(string threadTitle, IEnumerable<Post> posts, string boardId) => await downloadManager.DownloadFiles(new DownloadRequest()
        {
            Thread = new DownloadRequestThreadDetails()
            {
                ThreadTitle = threadTitle,
                BoardId = boardId,
                Posts = posts

            }
        });
    }
}