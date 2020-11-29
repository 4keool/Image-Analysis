#include <QtWidgets>

#include "PreviewWindow.h"


PreviewWindow::PreviewWindow(QWidget *parent)
	: QWidget(parent)
{
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
