using Microsoft.AspNetCore.Components.Web;

namespace WorkManagerClient.Managers
{
    class PageManager
    {
        public int maxElement { get; set; }
        public int maxPage { get; set; }
        public int currentPage { get; set; }
        public int pageSize { get; set; }


        public PageManager()
        {
            pageSize = 10;
            currentPage = 1;
        }

        public void calcMaxPage()
        {
            maxPage = maxElement / pageSize;
            if (maxElement % pageSize != 0) maxPage++;
            currentPage = 1;
        }

        public async Task changePage(MouseEventArgs e, int change, Func<Task> callback)
        {
            if (currentPage + change >= 1 && currentPage + change <= maxPage) currentPage += change;
            await callback();
        }

        public string showPageCount()
        {
            return currentPage + " / " + maxPage;
        }

        public async Task setPageSize(string value, Func<Task> callback)
        {
            pageSize = int.Parse(value);
            calcMaxPage();
            await callback();
        }
    }
}
