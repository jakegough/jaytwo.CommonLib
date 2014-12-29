using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using jaytwo.CommonLib.Drawing;
using System.IO;

namespace jaytwo.CommonLib.ExtensionMethods
{
    public static class DrawingExtensionMethods
    {
		public static Image AddBackgroundColor(this Image imageIn, Color color)
		{
			using (imageIn)
			{
				return DrawingUtilities.GetImageWithBackground(imageIn, color);
			}
		}

		public static Image Crop(this Image imageIn, Rectangle bounds)
		{
			using (imageIn)
			{
				return DrawingUtilities.GetCroppedImage(imageIn, bounds);
			}
		}

        public static Image Resize(this Image imageIn, int maxDimension)
        {
			using (imageIn)
			{
				return DrawingUtilities.GetResizedImage(imageIn, maxDimension);
			}
        }

        public static Image Resize(this Image imageIn, Size maxSize)
		{
			using (imageIn)
			{
				return DrawingUtilities.GetResizedImage(imageIn, maxSize);
			}
		}

		public static Image ResizeExact(this Image imageIn, Size exactSize)
		{
			using (imageIn)
			{
				return DrawingUtilities.GetResizedExactImage(imageIn, exactSize);
			}
		}

		public static Image ResizeCanvas(this Image imageIn, Size newCanvasSize)
		{
			using (imageIn)
			{
				return DrawingUtilities.ResizeImageCanvas(imageIn, newCanvasSize);
			}
		}

        public static void SaveJpeg(this Image imageIn, Stream stream)
        {
            DrawingUtilities.SaveJpeg(imageIn, stream);
        }
        public static void SaveJpeg(this Image imageIn, Stream stream, int qualityPercent)
        {
            DrawingUtilities.SaveJpeg(imageIn, stream, qualityPercent);
        }
        public static void SavePng(this Image imageIn, Stream stream)
        {
            DrawingUtilities.SavePng(imageIn, stream);
        }

        public static Image RotateRadians(this Image imageIn, double radians)
        {
			using (imageIn)
			{
				return DrawingUtilities.RotateImageRadians(imageIn, radians);
			}
        }
        public static Image RotateDegrees(this Image imageIn, double degrees)
        {
			using (imageIn)
			{
				return DrawingUtilities.RotateImageDegrees(imageIn, degrees);
			}
        }

		public static Image Overlay(this Image imageIn, params Image[] overlayImages)
		{
			using (imageIn)
			{
				return DrawingUtilities.GetImageWithOverlay(imageIn, overlayImages);
			}
		}

		public static Image Background(this Image imageIn, Color color)
		{
			using (imageIn)
			{
				return DrawingUtilities.GetImageWithBackground(imageIn, color);
			}
		}

		public static Size? TryParseSize(this string value)
		{
			return DrawingUtilities.ParseSize(value);
		}
    }
}
