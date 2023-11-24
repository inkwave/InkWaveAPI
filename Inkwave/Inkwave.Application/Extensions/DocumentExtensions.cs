using Inkwave.Domain.Document;
using System.Text;

namespace Inkwave.Application.Extensions
{
    public static class DocumentExtensions
    {
        public static FileFormat GetFileFormat(this byte[] bytes)
        {
            FileType fileType = bytes.GetFileType();
            if (fileType == null) return FileFormat.unknown;

            #region office, excel, ppt and documents, xml, pdf, rtf, msdoc
            if (fileType.Extension == "pdf") return FileFormat.PDF;
            if (fileType.Extension == "doc") return FileFormat.WORD;
            if (fileType.Extension == "docx") return FileFormat.WORD;
            if (fileType.Extension == "xls") return FileFormat.EXCEL;
            if (fileType.Extension == "xlsx") return FileFormat.EXCEL;
            if (fileType.Extension == "ppt") return FileFormat.PPT;
            if (fileType.Extension == "txt") return FileFormat.TXT_UTF8;
            #endregion
            #region Graphics jpeg, png, gif, bmp, ico
            if (fileType.Extension == "jpeg") return FileFormat.JPEG;
            if (fileType.Extension == "png") return FileFormat.PNG;
            if (fileType.Extension == "gif") return FileFormat.GIF;
            if (fileType.Extension == "bmp") return FileFormat.BMP;
            if (fileType.Extension == "ico") return FileFormat.ICO;
            #endregion

            return FileFormat.unknown;
        }
        public static ImageFormat GetImageFormat(this byte[] bytes)
        {
            var bmp = Encoding.ASCII.GetBytes("BM");     // BMP
            var gif = Encoding.ASCII.GetBytes("GIF");    // GIF
            var png = new byte[] { 137, 80, 78, 71 };              // PNG
            var tiff = new byte[] { 73, 73, 42 };                  // TIFF
            var tiff2 = new byte[] { 77, 77, 42 };                 // TIFF
            var jpeg = new byte[] { 255, 216, 255, 224 };          // jpeg
            var jpeg2 = new byte[] { 255, 216, 255, 225 };         // jpeg canon

            if (bmp.SequenceEqual(bytes.Take(bmp.Length)))
                return ImageFormat.bmp;

            if (gif.SequenceEqual(bytes.Take(gif.Length)))
                return ImageFormat.gif;

            if (png.SequenceEqual(bytes.Take(png.Length)))
                return ImageFormat.png;

            if (tiff.SequenceEqual(bytes.Take(tiff.Length)))
                return ImageFormat.tiff;

            if (tiff2.SequenceEqual(bytes.Take(tiff2.Length)))
                return ImageFormat.tiff;

            if (jpeg.SequenceEqual(bytes.Take(jpeg.Length)))
                return ImageFormat.jpeg;

            if (jpeg2.SequenceEqual(bytes.Take(jpeg2.Length)))
                return ImageFormat.jpeg;

            return ImageFormat.unknown;
        }
    }
}
