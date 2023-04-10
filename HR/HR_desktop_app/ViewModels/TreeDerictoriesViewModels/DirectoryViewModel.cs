using HR_desktop_app.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_desktop_app.ViewModels.TreeDerictoriesViewModels
{
    internal class DirectoryViewModel : ViewModel
    {
        private readonly DirectoryInfo _DirectorInfo;
        public IEnumerable<DirectoryViewModel> SubDirectories => _DirectorInfo
            .EnumerateDirectories()
            .Select(dir_inf => new DirectoryViewModel(dir_inf.FullName));

        public IEnumerable<FileViewModel> Filies => _DirectorInfo
            .EnumerateFiles()
            .Select(file => new FileViewModel(file.FullName));

        public IEnumerable<object> DirectoryItems =>
            SubDirectories.Cast<object>().Concat(Filies);

        public string Name =>_DirectorInfo.Name;
        public string Path =>_DirectorInfo.FullName;
        public DateTime CreationTime => _DirectorInfo.CreationTime;

        public DirectoryViewModel(string path) =>_DirectorInfo = new DirectoryInfo(path);
        
    }

    internal class FileViewModel : ViewModel
    {
        private readonly FileInfo _FileInfo;
        public FileViewModel(string path) => _FileInfo = new FileInfo(path);
        public string Name => _FileInfo.Name;
        public string Path => _FileInfo.FullName;
        public DateTime CreationTime => _FileInfo.CreationTime;
    }
}
