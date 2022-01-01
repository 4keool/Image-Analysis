#pragma once
#ifndef PREVIEWWINDOW_H
#define PREVIEWWINDOW_H

#include <QWidget>
#include <opencv2/core/core.hpp>
#include <opencv2/highgui.hpp>
#include <opencv2/opencv.hpp>

QT_BEGIN_NAMESPACE
class QLabel;
class QPushButton;
class QTextEdit;
class QString;
QT_END_NAMESPACE


class PreviewWindow : public QWidget
{
	Q_OBJECT

public:
	PreviewWindow(QWidget *parent = 0);

	void imageProcessing(QString text);
	void showImage(cv::Mat img);

private:
	QPushButton *closeButton;

	cv::Mat originalImage;
	cv::Mat processedImage;
	QLabel *imageLabel;


	long MoniterWidth;
	long MoniterHeight;

};


#endif
