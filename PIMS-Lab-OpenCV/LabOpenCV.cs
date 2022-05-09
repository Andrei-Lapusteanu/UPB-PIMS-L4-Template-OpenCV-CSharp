using System;
using System.IO;

// Inlcude OpenCV C# wrapper (currently using OpenCV 4.5.5)
using OpenCvSharp;

namespace PIMS_Lab_OpenCV
{
    internal class LabOpenCV
    {
        // Go back twice from .exe and into 'imgs' folder
        const string baseImgFolder = "..\\..\\imgs\\";
        const string lennaInputImgPath = baseImgFolder + "Lenna_original.png";
        const string catInputImgPath = baseImgFolder + "cat-in-snow.jpeg";

        static void Main(string[] args)
        {
            LabOpenCV labOpenCV = new LabOpenCV();

            // Load image. Use the 'Cv2' namespace to access OpenCV functions
            Mat lennaInputImg = Cv2.ImRead(lennaInputImgPath);

            /** TODO: Exercise 1 - Sign your image */
            Cv2.PutText(lennaInputImg,                              /* img to write on */
                        "FirstName LastName",                       /* text */
                        new Point(10, 30),                          /* text position */
                        HersheyFonts.HersheySimplex,                /* font face */
                        1,                                          /* font size */
                        new Scalar(/*B*/ 255, /*G*/ 255, /*R*/ 0),  /* font color */
                        2                                           /* font thickness */);

            // Display image in new window
            Cv2.ImShow("Input image", lennaInputImg);

            /** Point operations
             *  Convert to graycale - already implemented, follow methodology for other exercises */
            //  Create a new single channel (MatType.CV_8UC1) matrix of black pixels (Zeros). For 3-channel color images use 'MatType.CV_8UC3'
            Mat grayscaleImg = Mat.Zeros(lennaInputImg.Size(), MatType.CV_8UC1);

            // 'Cv2.CvtColor' converts an image from one color space to another. Enum 'ColorConversionCodes' specifies conversion type
            //  Observe that conversion is specified from a 3-channel matrix (BGR) to grascale (GRAY)
            /* V1 */ Cv2.CvtColor(lennaInputImg, grayscaleImg, ColorConversionCodes.BGR2GRAY);
            /* V2    grayscaleImg = lennaInputImg.CvtColor(ColorConversionCodes.BGR2GRAY); <--- operate directly on matrix */

            // Display image in new window
            Cv2.ImShow("Grayscale image", grayscaleImg);

            // Save image in 'imgs' directory
            labOpenCV.SaveImage(grayscaleImg, "Grayscale Image.png");

            //----------------------------------------------------------------------------------//

            /** Point operations
             *  TODO Exercise 2: Binarization or static-value thresholding of the grayscale image. Compute both 'Binary' with a threshold of 128 and 'Otsu' (optimal) thresholding 
             *      - Tip: 'Cv2.Threshold' can be used to perform the operation. Change function arguments to select between 'Binary' and 'Otsu' thresholdings
             *  Compute the images, display and save them */

            //----------------------------------------------------------------------------------//

            /** Point operations
              * TODO Exercise 3: Invert the grayscale image (image negative) 
              *     - Tip: 'Cv2.BitwiseNot' inverts image bytes
              *  Compute the image, display and save it */

            //----------------------------------------------------------------------------------//

            /** Point operations
             *  TODO Exercise 4: Equalize histogram of the grayscale image
             *      - Tip: Refer to https://docs.opencv.org/3.4/d4/d1b/tutorial_histogram_equalization.html and adapt needed function
             *  Compute the image, display and save it */

            //----------------------------------------------------------------------------------//

            /** Geometric transformations - Image flip / mirroring 
             *  TODO Exercise 5: Flip image about Y axis
             *      - Tip: 'Cv2.Flip' performs the needed operation, adapt parameters to suit your needs
             *  Compute the image, display and save it */

            //----------------------------------------------------------------------------------//

            /** Noise generation 
             *  TODO Exercise 6: (Manually) add salt and pepper noise to the grayscale image. Each pixel has a probability of
             *  0.05 (5%) to be affected by noise. Each noise pixel has a 50/50 chance to be black/white 
             *      - Tip: img.Cols and img.Rows can be used to iterate through the matrix 
             *      - Tip: img.At<byte>(x,y) can be used to access pixels for single channel images, for BGR images you need img.At<Vec3b>(x,y)
             *  Compute the image, display and save it */

            //----------------------------------------------------------------------------------//

            /** Neighbourhood operations
             *  TODO Exercise 7: Average blur the previously created salt and pepper noisy image using a 5x5 kernel 
             *      - Tip: 'Cv2.Blur' performs the needed operation, adapt parameters to suit your needs
             *  Compute the image, display and save it */

            //----------------------------------------------------------------------------------//

            /** Neighbourhood operations 
             *  TODO Exercise 8: Median blur the previously created salt and pepper noisy image using a 5x5 kernel
             *       - Tip: 'Cv2.MedianBlur' performs the needed operation, adapt parameters to suit your needs
             *  Observe the differences between average and median blurring on this example
             *  Compute the image, display and save it */

            //----------------------------------------------------------------------------------//

            /** Gradient
             *  TODO Exercise 9: Compute the 1D gradient of the grayscale image using the Sobel operator
             *  - Understand and adapt python code from here https://pyimagesearch.com/2021/05/12/image-gradients-with-opencv-sobel-and-scharr/ 
             *  - Basically, you need to compute 2 first order derivatives for the image, one for the 
             *    x direction and another for the y direction and then combine these into a single image 
             *  - The result will the the combined dx and dy gradients
             *  - Gradients and the Laplacian are very helpful (and are used) when computing image edges
             *  Compute the image, display and save it */

            //----------------------------------------------------------------------------------//

            /** Gradient
             * TODO Exercise 10: Compute the Laplacian (2nd order derivative) of the grayscale image
             * - Use either the Sobel methodolody from abobe (change the dx & dy params) or the built-in Laplacian function 
             * - Optional recommendation: Compute the Lapalcian both ways, the results sould be the same
             *  Compute the image, display and save it */

            //----------------------------------------------------------------------------------//

            /** Image edges
             *  TODO Exercise 11:Compute the edges for the grayscale image using the Canny method
             *      - Tip: 'Cv2.Canny' performs the needed operation. For further details, refer to https://docs.opencv.org/4.x/dd/d1a/group__imgproc__feature.html#ga04723e007ed888ddf11d9ba04e2232de
             *  Compute the image, display and save it */

            //----------------------------------------------------------------------------------//

            /** This is a simple example of how to extract parts on an image
             *  More specifically, it shows how we can get the contours of an object of interest by:
             *      - (TODO) Grayscaling
             *      - (TODO) Thresholding (with an appropiate value, we'll use the trusted 'ochiometric' engineering principle) 
             *      - (TODO) Inverting (if necessary) 
             *      - Computing the contours of the image as a Point[][] data structure
             *      - Drawing the contours, overlay them on the original image
             *      - Compute contour area
             *      - Compute and draw contour center
             * TODO Exercise 12: Complete the TOOO's below to compute the image and save the result */

            // Load image
            Mat catInputImg = Cv2.ImRead(catInputImgPath);
            Mat catGrayscaleImg = Mat.Zeros(catInputImg.Size(), MatType.CV_8UC1);
            Mat catThreshImg = Mat.Zeros(catInputImg.Size(), MatType.CV_8UC1);

            // (!) Uncomment to see input image
            // Cv2.ImShow("catInputImg", catInputImg);

            // TODO: Grayscale image

            // TODO: Threshold the grayscale image in order to separate it from the background as best as possible. Set threshold value as you see fit

            // TODO: Invert image

            // Compute contours of the image. Note that 'RetrievalModes' specifies in which way to extarct contours (tree, list, external contours, etc.)
            Cv2.FindContours(catThreshImg, out Point[][] contours, out HierarchyIndex[] hierarchy, RetrievalModes.External, ContourApproximationModes.ApproxSimple);

            // Draw contours on the color image. '-1' indicates that all contours should be drawn
            Cv2.DrawContours(catInputImg, contours, -1, Scalar.All(0), 2);

            // (!) Uncomment to see result
            // Cv2.ImShow("catInputImg contours", catInputImg);

            // Find largest contour index by area
            double largestContourArea = -float.MaxValue;
            int largestContourIndex = -1;
            for (int i = 0; i < contours.Length; i++)
            {
                // Compute contour area
                double currentContourArea = Cv2.ContourArea(contours[i]);

                // Find largest contour's index
                if (currentContourArea > largestContourArea)
                {
                    largestContourIndex = i;
                    largestContourArea = currentContourArea;
                }
            }

            if(contours.Length > 0)
            {
                // Compute contour center point
                // For further details, refer to: https://pyimagesearch.com/2016/02/01/opencv-center-of-contour/
                Moments mom = Cv2.Moments(contours[largestContourIndex]);
                int cx = (int)(mom.M10 / mom.M00);
                int cy = (int)(mom.M01 / mom.M00);

                // Draw a circle representing the center point
                catInputImg.Circle(cx, cy, 10, Scalar.All(255), -1);

                // (!) Uncomment to see result. There should be white circle at the contour's center point (after finishing TODOs)
                // Cv2.ImShow("catInputImg center", catInputImg);
            }

            //----------------------------------------------------------------------------------//

            /** TODO Exercise 12: Compute which candidate circle (cyan) is closest to the target circle (red)
             *      - Find a way to get both the candidate circles positions and the target circle position
             *      - Most functionality you'll implement follows the example presented above. You'll have to adapt it to your needs
             *          - Tip: Use 'Cv2.Split()' to split the color image into single channels
             *            Think about how to compute stuff for the candidate and target circles separately
             *      - Draw a white 1px line ('Cv2.Line') from each candidate circle's center to the target's circle center
             *      - Write on the image the distance in pixels
             *      - Finally, highlight (draw a colored contour) around the closest candidate circle */

            // (!) Uncomment below to generate test image
            // Mat circlesImg = labOpenCV.GenerateCirclesImage();
            // Cv2.ImShow("Rand circles image original", circlesImg);


            // Wait for input (if not written, program will auto-close).
            Cv2.WaitKey(0);
        }

        private void SaveImage(Mat img, string fileNameWithExtension)
        {
            string path = Directory.GetCurrentDirectory() + "\\" + baseImgFolder + fileNameWithExtension;
            Cv2.ImWrite(path, img);
        }

        private Mat GenerateCirclesImage()
        {
            Size matSize = new Size(1000, 1000);
            Scalar candidateCircleColor = new Scalar(255, 255, 0);              // Cyan
            Scalar targetCircleColor = new Scalar(0, 0, 255);                   // Red
            Mat circlesImg = Mat.Zeros(matSize, MatType.CV_8UC3);               // Color (BGR) image
            int gridStep = 100;
            int rowPxStart = gridStep, colPxStart = gridStep;                   // Where to start drawing candidate circles
            int rowPxEnd = matSize.Height - rowPxStart;                         // Where to stop drawing candidate circles
            int colPxEnd = matSize.Width - colPxStart;
            int circleDrawExclusionStart = 300, circleDrawExclusionEnd = 600;   // Draw candidate circles outside this area
            int targetCircleRadius = 30;                                        
            int circleMinRadius = 10;
            int circleMaxRadius = 45;
            float circleProbability = 0.25f;

            Random rnd = new Random();

            // For each row
            for (int rows = rowPxStart; rows <= rowPxEnd; rows += gridStep)
                // For each column
                for (int cols = colPxStart; cols <= colPxEnd; cols += gridStep)
                    // If not in 'exlcusion zone'
                    if ((rows <= circleDrawExclusionStart || rows >= circleDrawExclusionEnd) &&
                        (cols <= circleDrawExclusionStart || cols >= circleDrawExclusionEnd))
                        // If a circle should be drawn
                        if (rnd.NextDouble() < circleProbability)
                            // Draw candidate circle with a random radius in the specified range
                            circlesImg.Circle(cols, rows, rnd.Next(circleMinRadius, circleMaxRadius), candidateCircleColor, -1);

            // Draw target circle inside 'exclusion zone'
            int borderOffet = 50;
            circlesImg.Circle(
                rnd.Next(circleDrawExclusionStart + borderOffet, circleDrawExclusionEnd - borderOffet), 
                rnd.Next(circleDrawExclusionStart + borderOffet, circleDrawExclusionEnd - borderOffet), 
                targetCircleRadius,
                targetCircleColor, 
                -1);

            return circlesImg;
        }
    }
}



















