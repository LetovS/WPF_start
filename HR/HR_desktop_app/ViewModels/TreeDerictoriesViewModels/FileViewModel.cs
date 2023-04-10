using HR_desktop_app.ViewModels.Base;
using System;
using System.IO;

namespace HR_desktop_app.ViewModels.TreeDerictoriesViewModels
{
    internal class FileViewModel : ViewModel
    {
        private readonly FileInfo _FileInfo;
        public FileViewModel(string path) => _FileInfo = new FileInfo(path);
        public string Name => _FileInfo.Name;
        public string Path => _FileInfo.FullName;
        public DateTime CreationTime => _FileInfo.CreationTime;
    }
}
