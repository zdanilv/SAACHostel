using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAACHostel.Services
{
    internal class OpenDialogAddPhoto
    {
        public static byte[] ResultDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".*";
            openFileDialog.Filter = "All Files (*.*)|*.*|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            if (openFileDialog.ShowDialog() == true)
            {
                using (FileStream fileStream = File.OpenRead(openFileDialog.FileName))
                {
                    byte[]? buffer = new byte[fileStream.Length];
                    fileStream.Read(buffer, 0, buffer.Length);
                    return buffer;
                };
            }
            else return null;
        }
    }
}
