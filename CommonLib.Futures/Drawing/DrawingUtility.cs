using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;
using jaytwo.Common.Parse;
using jaytwo.Common.System;
using jaytwo.Common.IO;

namespace jaytwo.Common.Futures.Drawing
{
	public static class DrawingUtility
	{
		const int DEFAULT_IMAGE_QUALITY = 90;

		public static void SavePng(Image imageIn, Stream streamOut)
		{
			if (streamOut.CanSeek)
			{
				imageIn.Save(streamOut, ImageFormat.Png);
			}
			else
			{
				using (var imageStream = new MemoryStream())
				{
					imageIn.Save(imageStream, ImageFormat.Png);
					StreamUtility.CopyStreamToStream(imageStream, streamOut);
				}
			}
		}

		private static ImageCodecInfo jpegImageCodecInfo = ImageCodecInfo.GetImageEncoders()
			.FirstOrDefault(x => x.MimeType.Equals("image/jpeg", StringComparison.CurrentCultureIgnoreCase));

		public static void SaveJpeg(Image imageIn, Stream streamOut)
		{
			SaveJpeg(imageIn, streamOut, DEFAULT_IMAGE_QUALITY);
		}
		public static void SaveJpeg(Image imageIn, Stream streamOut, int qualityPercent)
		{
			EncoderParameters encoderParameters = new EncoderParameters(1);
			encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, qualityPercent);
			imageIn.Save(streamOut, jpegImageCodecInfo, encoderParameters);
		}

		public static int GetScaleWidth(int currentWidth, int currentHeight, int maxWidth, int maxHeight)
		{
			return GetScaleSize(currentWidth, currentHeight, maxWidth, maxHeight).Width;
		}

		public static int GetScaleHeight(int currentWidth, int currentHeight, int maxWidth, int maxHeight)
		{
			return GetScaleSize(currentWidth, currentHeight, maxWidth, maxHeight).Height;
		}

		public static Size GetScaleSize(int currentWidth, int currentHeight, int maxDimension)
		{
			return GetScaleSize(new Size(currentWidth, currentHeight), new Size(maxDimension, maxDimension));
		}

		public static Size GetScaleSize(int currentWidth, int currentHeight, int maxWidth, int maxHeight)
		{
			return GetScaleSize(new Size(currentWidth, currentHeight), new Size(maxWidth, maxHeight));
		}

		public static Size GetScaleSize(Size currentSize, Size maxSize)
		{
			if (maxSize.Width < currentSize.Width || maxSize.Height < currentSize.Height)
			{
				double ratioX = (double)maxSize.Width / (double)currentSize.Width;
				double ratioY = (double)maxSize.Height / (double)currentSize.Height;
				double ratio = Math.Min(ratioX, ratioY);

				return new Size(
					(int)((double)currentSize.Width * ratio),
					(int)((double)currentSize.Height * ratio));
			}
			else
			{
				return currentSize;
			}
		}

		private static Graphics GetHighQualityGraphics(Image image)
		{
			var graphics = Graphics.FromImage(image);
			graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			graphics.SmoothingMode = SmoothingMode.AntiAlias;

			return graphics;
		}

		public static Image GetResizedImage(Image imageIn, int maxDimension)
		{
			return GetResizedImage(imageIn, new Size(maxDimension, maxDimension));
		}
		public static Image GetResizedImage(Image imageIn, Size maxSize)
		{
			if (imageIn != null)
			{
				Size scaleSize = GetScaleSize(imageIn.Size, maxSize);

				if (scaleSize.Height != imageIn.Height || scaleSize.Width != imageIn.Width)
				{
					return GetResizedExactImage(imageIn, scaleSize);
				}
				else
				{
					return new Bitmap(imageIn);
				}
			}
			else
			{
				return null;
			}

		}

		public static Image GetResizedExactImage(Image imageIn, Size exactSize)
		{
			if (imageIn != null)
			{
				var resizedImage = new Bitmap(exactSize.Width, exactSize.Height);
				using (var graphics = GetHighQualityGraphics(resizedImage))
				{
					graphics.ResetTransform();
					graphics.DrawImage(imageIn, 0, 0, exactSize.Width, exactSize.Height);
				}

				return resizedImage;
			}
			else
			{
				return null;
			}
		}

		public static Image RotateImageDegrees(Image imageIn, double degrees)
		{
			double radians = 360d / (Math.PI * 2);
			return RotateImageRadians(imageIn, radians);
		}
		public static Image RotateImageRadians(Image imageIn, double radians)
		{
			radians = radians % (2 * Math.PI);
			if (radians < 0)
			{
				radians = (2 * Math.PI) + radians;
			}

			double x1 = Math.Abs(Math.Sin(radians) * imageIn.Height);
			double x2 = Math.Abs(Math.Cos(radians) * imageIn.Width);
			double newX = x1 + x2;

			double y1 = Math.Abs(Math.Cos(radians) * imageIn.Height);
			double y2 = Math.Abs(Math.Sin(radians) * imageIn.Width);
			double newY = y1 + y2;

			Point[] pGram = new Point[2];

			if (radians < 0.5d * Math.PI)
			{
				pGram[0] = new Point((int)x1, 0);
				pGram[1] = new Point((int)newX, (int)y2);
				pGram[2] = new Point(0, (int)y1);
			}
			else if (radians < Math.PI)
			{
				pGram[0] = new Point((int)newX, (int)y1);
				pGram[1] = new Point((int)x1, (int)newY);
				pGram[2] = new Point((int)x2, 0);
			}
			else if (radians < 1.5d * Math.PI)
			{
				pGram[0] = new Point((int)x2, (int)newY);
				pGram[1] = new Point(0, (int)y1);
				pGram[2] = new Point((int)newX, (int)y2);
			}
			else
			{
				pGram[0] = new Point(0, (int)y2);
				pGram[1] = new Point((int)x2, 0);
				pGram[2] = new Point((int)x1, (int)newY);
			}

			Bitmap bitmap = new Bitmap((int)newX, (int)newY);

			using (var graphics = GetHighQualityGraphics(bitmap))
			{
				graphics.ResetTransform();
				graphics.DrawImage(imageIn, pGram);
			}

			return bitmap;
		}


		public static Image GetImageWithOverlay(Image imageIn, params Image[] overlayImages)
		{
			var imageOut = new Bitmap(imageIn);

			using (var graphics = GetHighQualityGraphics(imageOut))
			{
				foreach (var overlay in overlayImages)
				{
					using (var resized = GetResizedImage(overlay, imageOut.Size))
					{
						int x = (imageOut.Width - resized.Width) / 2;
						int y = (imageOut.Height - resized.Height) / 2;

						graphics.DrawImage(overlay, x, y, resized.Width, resized.Height);
					}
				}
			}

			return imageOut;
		}

		public static Image GetImageWithBackground(Image imageIn, Color color)
		{
			var imageOut = new Bitmap(imageIn.Width, imageIn.Height);

			using (var graphics = Graphics.FromImage(imageOut))
			{
				var brush = new SolidBrush(color);
				var rectangle = new Rectangle(0, 0, imageOut.Width, imageOut.Height);
				graphics.FillRectangle(brush, rectangle);
				graphics.DrawImage(imageIn, 0, 0);
			}

			return imageOut;
		}

		public static Image GetCroppedImage(Image imageIn, Rectangle bounds)
		{
			var imageOut = new Bitmap(bounds.Width, bounds.Height);

			using (var graphics = GetHighQualityGraphics(imageOut))
			{
				graphics.DrawImage(imageIn,
					new Rectangle(0, 0, bounds.Width, bounds.Height),
					bounds,
					GraphicsUnit.Pixel);
			}

			return imageOut;
		}

		public static Image ResizeImageCanvas(Image imageIn, Size newCanvasSize)
		{
			var imageOut = new Bitmap(newCanvasSize.Width, newCanvasSize.Height);

			using (var graphics = GetHighQualityGraphics(imageOut))
			{
				var x = (newCanvasSize.Width - imageIn.Width) / 2;
				var y = (newCanvasSize.Height - imageIn.Height) / 2;

				graphics.DrawImage(imageIn,
					new Rectangle(x, y, imageIn.Width, imageIn.Height),
					new Rectangle(0, 0, imageIn.Width, imageIn.Height),
					GraphicsUnit.Pixel);
			}

			return imageOut;
		}

		private static readonly Regex sizeRegex = new Regex(@"(?<W>\d+)[x,](?<H>\d+)|(((w(?<W>\d+))|((?<W>\d+)w)|(h(?<H>\d+))|((?<H>\d+)h))[x,]?)+|(?<SQUARE>\d+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
		public static Size? ParseSize(string value)
		{
			if (value != null)
			{
				var match = sizeRegex.Match(value);

				if (match.Success)
				{
					var square = ParseUtility.TryParseInt32(match.Groups["SQUARE"].Value);
					var width = ParseUtility.TryParseInt32(match.Groups["W"].Value);
					var height = ParseUtility.TryParseInt32(match.Groups["H"].Value);

					if (width.HasValue && width.Value > 0 && height.HasValue && height.Value > 0)
					{
						return new Size(width.Value, height.Value);
					}
					else if (width.HasValue && width.Value > 0)
					{
						return new Size(width.Value, int.MaxValue);
					}
					else if (height.HasValue && height.Value > 0)
					{
						return new Size(int.MaxValue, height.Value);
					}
					else if (square.HasValue && square.Value > 0)
					{
						return new Size(square.Value, square.Value);
					}
				}
			}

			return null;
		}
	}
}