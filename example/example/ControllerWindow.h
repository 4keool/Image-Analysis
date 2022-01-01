#ifndef CONTROLLERWINDOW_H
#define CONTROLLERWINDOW_H

#include <QWidget>

#include "previewwindow.h"

QT_BEGIN_NAMESPACE
class QGroupBox;
class QLabel;
class QPushButton;
class QRadioButton;
QT_END_NAMESPACE


class ControllerWindow : public QWidget
{
	Q_OBJECT

public:
	ControllerWindow();
	bool path;

private slots:
	void updatePreview();



private:
	void createTypeGroupBox();
	QRadioButton *createRadioButton(const QString &text);

	PreviewWindow *previewWindow;

	QGroupBox *typeGroupBox;
	QPushButton *quitButton;

	QRadioButton *img_original;
	QRadioButton *img_gray;
	QRadioButton *img_canny;



};

#endif
