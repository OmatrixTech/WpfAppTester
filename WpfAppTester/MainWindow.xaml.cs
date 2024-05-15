using Custom.Net8.FileSystemWatcher;
using System.IO;
using System.Text;
using System.Windows;



namespace WpfAppTester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CustomFileSystemWatcher FileSystemWatcher { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            FileSystemWatcher = new CustomFileSystemWatcher()
            {
                //This field is required when the user requires notifications from the file system for any changes that occur.
                EnableRaisingEvents = true,

                //When the user wishes to monitor changes not only in the root folder but also in its subfolders.
                //If this feature is disabled, changes that occur in the root folder will not be monitored.
                IncludeSubdirectories = true,

                //Substitute it with the filepath of your choice.
                Path = @"C:\Users\sanjay\Desktop\FileGallary",

                //This field must be enabled if the user intends to initiate and monitor changes in a file system.
                FileWatcherStarted = true,
                
                //The use of the combination of "FileFilter" and "ExtensionType" is solely intended for situations where the user explicitly wishes to inspect changes within a single file
                //FileFilter = "DemoFile",
                //ExtensionType = ".txt",

                //If the user wishes to exclusively search for files with any extension type.
                //FileFilter = "*.txt",
                
                // If the user wants to search for a file of any type with any extension.
                FileFilter = "*.*",
            };
            FileSystemWatcher.FileCreated += FileSystemWatcher_FileCreated;
            FileSystemWatcher.FileDeleted += FileSystemWatcher_FileDeleted;
            FileSystemWatcher.FileModified += FileSystemWatcher_FileModified;
            FileSystemWatcher.FileRenamed += FileSystemWatcher_FileRenamed;
        }

        private void FileSystemWatcher_FileRenamed(object? sender, Custom.Net8.FileSystemWatcher.Utilities.CustomRenamedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void FileSystemWatcher_FileModified(object? sender, Custom.Net8.FileSystemWatcher.Utilities.CustomFileSystemEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void FileSystemWatcher_FileDeleted(object? sender, Custom.Net8.FileSystemWatcher.Utilities.CustomFileSystemEventArgs e)
        {
            // throw new NotImplementedException();
        }

        private void FileSystemWatcher_FileCreated(object? sender, Custom.Net8.FileSystemWatcher.Utilities.CustomFileSystemEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void BtnFileCreated_Click(object sender, RoutedEventArgs e)
        {
            // Check if the file already exists
            if (!File.Exists(System.IO.Path.Combine(@"C:\Users\sanjay\Desktop\FileGallary", "DemoFile.txt")))
            {
                // Create the file and write some content
                using (FileStream fs = File.Create(System.IO.Path.Combine(@"C:\Users\sanjay\Desktop\FileGallary", "DemoFile.txt")))
                {
                    // Write content to the file
                    string content = TxtBxDemo.Text;
                    byte[] bytes = Encoding.UTF8.GetBytes(content);
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            else
            {
                MessageBox.Show("File already exists.");
            }
        }

        private void BtnFileModified_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(System.IO.Path.Combine(@"C:\Users\sanjay\Desktop\FileGallary", "DemoFile.txt")))
            {
                File.WriteAllText(System.IO.Path.Combine(@"C:\Users\sanjay\Desktop\FileGallary", "DemoFile.txt"), TxtBxDemo.Text);
            }
            else
            {
                MessageBox.Show("File does not exists.");
            }
        }

        private void BtnFileDeleted_Click(object sender, RoutedEventArgs e)
        {
            File.Delete(System.IO.Path.Combine(@"C:\Users\sanjay\Desktop\FileGallary", "DemoFile.txt"));
        }

        private void BtnFileRenamed_Click(object sender, RoutedEventArgs e)
        {
            // Specify the current file path and the new file path
            string currentFilePath = @"C:\Users\sanjay\Desktop\FileGallary\DemoFile.txt";
            string newFilePath = @"C:\Users\sanjay\Desktop\FileGallary\Renamedfilename.txt";
            try
            {
                // Create a FileInfo  
                System.IO.FileInfo fi = new System.IO.FileInfo(currentFilePath);
                // Check if file is there  
                if (fi.Exists)
                {
                    // Move file with a new name. Hence renamed.  
                    fi.MoveTo(newFilePath);
                    Console.WriteLine("File Renamed.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }


    }
}