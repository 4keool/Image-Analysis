#include <QtWidgets>

#include "PreviewWindow.h"


PreviewWindow::PreviewWindow(QWidget *parent)
	: QWidget(parent)
{
	MoniterWidth = GetSystemMetrics(SM_CXSCREEN);
	MoniterHeight = GetSystemMetrics(SM_CYSCREEN);

	imageLabel = new QLabel();

	closeButton = new QPushButton(tr("&Close"));
	connect(closeButton, SIGNAL(clicked()), this, SLOT(close()));

	QVBoxLayout *layout = new QVBoxLayout;
	layout->addWidget(imageLabel);
	layout->addWidget(closeButton);
	setLayout(layout);

	setWindowTitle(tr("Preview"));


	originalImage = cv::imread("1.jpg");
	if (originalImage.data)
	{
		cv::cvtColor(originalImage, originalImage, cv::COLOR_BGR2RGB);



		if (originalImage.rows > MoniterHeight)
		{
			long resize_hei = MoniterHeight * 0.8;
			float ImageRatio = (float)resize_hei / originalImage.rows;
			if (ImageRatio == 0)
				ImageRatio = 1;

			long resize_wid = originalImage.cols * ImageRatio;

			if (resize_wid > MoniterWidth)
			{
				long reresize_wid = MoniterWidth * 0.8;
				ImageRatio = (float)reresize_wid / originalImage.cols;
				if (ImageRatio == 0)
					ImageRatio = 1;

				long reresize_hei = originalImage.rows * ImageRatio;

				resize_wid = reresize_wid;
				resize_hei = reresize_hei;
			}

			if(resize_wid != 0 && resize_hei != 0)
				cv::resize(originalImage, originalImage, cv::Size(resize_wid, resize_hei), 0, 0);
		}

	}

}


void PreviewWindow::imageProcessing(QString  text)
{
	QWidget::setWindowFlags(Qt::Window);

	setWindowTitle(text);

	if (!text.compare("original", Qt::CaseInsensitive))
	{
		showImage(originalImage);
	}
	else  if (!text.compare("gray", Qt::CaseInsensitive))
	{
		cv::Mat gray;
		cv::cvtColor(originalImage, gray, cv::COLOR_RGB2GRAY);
		cv::cvtColor(gray, processedImage, cv::COLOR_GRAY2RGB);
		showImage(processedImage);
	}
	else if (!text.compare("canny", Qt::CaseInsensitive))
	{
		cv::Mat gray;
		cv::cvtColor(originalImage, gray, cv::COLOR_RGB2GRAY);
		cv::Canny(gray, processedImage, 150, 150);
		cv::cvtColor(processedImage, processedImage, cv::COLOR_GRAY2RGB);
		showImage(processedImage);
	}


}


void PreviewWindow::showImage(cv::Mat img)
{
	if (img.data)
	{
		QImage _img(img.data, img.cols, img.rows, QImage::Format_RGB888);
		imageLabel->setPixmap(QPixmap::fromImage(_img));
	}
	else
	{
		imageLabel->setText("Cannot load the input image!");
	}
}
