using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using jaytwo.Common.Drawing;
using System.IO;

namespace jaytwo.Common.Drawing
{
    public static class DrawingExtensionMethods
    {
		public static Image AddBackgroundColor(this Image imageIn, Color color)
		{
			using (imageIn)
			{
				return DrawingUtility.GetImageWithBackground(imageIn, color);
			}
		}

		public static Image Crop(this Image imageIn, Rectangle bounds)
		{
			using (imageIn)
			{
				return DrawingUtility.GetCroppedImage(imageIn, bounds);
			}
		}

        public static Image Resize(this Image imageIn, int maxDimension)
        {
			using (imageIn)
			{
				return DrawingUtility.GetResizedImage(imageIn, maxDimension);
			}
        }

        public static Image Resize(this Image imageIn, Size maxSize)
		{
			using (imageIn)
			{
				return DrawingUtility.GetResizedImage(imageIn, maxSize);
			}
		}

		public static Image ResizeExact(this Image imageIn, Size exactSize)
		{
			using (imageIn)
			{
				return DrawingUtility.GetResizedExactImage(imageIn, exactSize);
			}
		}

		public static Image ResizeCanvas(this Image imageIn, Size newCanvasSize)
		{
			using (imageIn)
			{
				return DrawingUtility.ResizeImageCanvas(imageIn, newCanvasSize);
			}
		}

        public static void SaveJpeg(this Image imageIn, Stream stream)
        {
            DrawingUtility.SaveJpeg(imageIn, stream);
        }
        public static void SaveJpeg(this Image imageIn, Stream stream, int qualityPercent)
        {
            DrawingUtility.SaveJpeg(imageIn, stream, qualityPercent);
        }
        public static void SavePng(this Image imageIn, Stream stream)
        {
            DrawingUtility.SavePng(imageIn, stream);
        }

        public static Image RotateRadians(this Image imageIn, double radians)
        {
			using (imageIn)
			{
				return DrawingUtility.RotateImageRadians(imageIn, radians);
			}
        }
        public static Image RotateDegrees(this Image imageIn, double degrees)
        {
			using (imageIn)
			{
				return DrawingUtility.RotateImageDegrees(imageIn, degrees);
			}
        }

		public static Image Overlay(this Image imageIn, params Image[] overlayImages)
		{
			using (imageIn)
			{
				return DrawingUtility.GetImageWithOverlay(imageIn, overlayImages);
			}
		}

		public static Image Background(this Image imageIn, Color color)
		{
			using (imageIn)
			{
				return DrawingUtility.GetImageWithBackground(imageIn, color);
			}
		}

		public static Size? TryParseSize(this string value)
		{
			return DrawingUtility.ParseSize(value);
		}
    }
}