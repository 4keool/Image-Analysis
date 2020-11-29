#include <QtWidgets>
#include "ControllerWindow.h"


ControllerWindow::ControllerWindow()
{
	previewWindow = new PreviewWindow(this);

	createTypeGroupBox();

	quitButton = new QPushButton(tr("&Quit"));
	connect(quitButton, SIGNAL(clicked()), qApp, SLOT(quit()));

	QHBoxLayout *bottomLayout = new QHBoxLayout;
	bottomLayout->addStretch();
	bottomLayout->addWidget(quitButton);

	QHBoxLayout *mainLayout = new QHBoxLayout;
	mainLayout->addWidget(typeGroupBox);
	mainLayout->addLayout(bottomLayout);
	setLayout(mainLayout);

	setWindowTitle(tr("Window Flags"));
	updatePreview();
}

void ControllerWindow::updatePreview()
{
	QString text;

	if (img_original->isChecked())
		text = "original";
	else if (img_gray->isChecked())
		text = "gray";
	else if (img_canny->isChecked())
		text = "canny";

	previewWindow->imageProcessing(text);


	QPoint pos = previewWindow->pos();
	if (pos.x() < 0)
		pos.setX(0);
	if (pos.y() < 0)
		pos.setY(0);
	previewWindow->move(pos);
	previewWindow->show();
}

void ControllerWindow::createTypeGroupBox()
{
	typeGroupBox = new QGroupBox(tr("ImageProcess"));

	img_original = createRadioButton(tr("original image"));
	img_gray = createRadioButton(tr("gray image"));
	img_canny = createRadioButton(tr("canny image"));

	img_original->setChecked(true);

	QGridLayout *layout = new QGridLayout;
	layout->addWidget(img_original, 0, 0);
	layout->addWidget(img_gray, 1, 0);
	layout->addWidget(img_canny, 2, 0);
	typeGroupBox->setLayout(layout);

}



QRadioButton *ControllerWindow::createRadioButton(const QString &text)
{
	QRadioButton *button = new QRadioButton(text);
	connect(button, SIGNAL(clicked()), this, SLOT(updatePreview()));
	return button;
}

