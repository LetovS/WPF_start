using HR_desktop_app.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_desktop_app.ViewModels.TreeDerictoriesViewModels
{
    internal class DirectoryViewModel : ViewModel
    {
        private readonly DirectoryInfo _DirectorInfo;
        public IEnumerable<DirectoryViewModel> SubDirectories
        {
            get
            {
                try
                {
                    return _DirectorInfo
                    .EnumerateDirectories()
                    .Select(dir_inf => new DirectoryViewModel(dir_inf.FullName));
                }
                catch (UnauthorizedAccessException e)
                {
                    
                    Debug.WriteLine(e.ToString());
                }
                return Enumerable.Empty<DirectoryViewModel>();
            }
        }

        public IEnumerable<FileViewModel> Filies
        {
            get
            {
                try
                {
                    var files = _DirectorInfo
                                .EnumerateFiles()
                                .Select(file => new FileViewModel(file.FullName));
                    return files;
                }
                catch (UnauthorizedAccessException e)
                {
                    
                    Debug.WriteLine(e.ToString());
                }
                return Enumerable.Empty<FileViewModel>();
            }
        }

        public IEnumerable<object> DirectoryItems        
        {
            get
            {
                try
                {
                    return SubDirectories.Cast<object>().Concat(Filies);
                }
                catch (UnauthorizedAccessException e)
                {
                    Debug.WriteLine(e.ToString());
                }
                return Enumerable.Empty<object>();
            }
        }



        public string Name =>_DirectorInfo.Name;
        public string Path =>_DirectorInfo.FullName;
        public DateTime CreationTime => _DirectorInfo.CreationTime;

        public DirectoryViewModel(string path) =>_DirectorInfo = new DirectoryInfo(path);
        
    }
}
