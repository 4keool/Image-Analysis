#include <QApplication>
#include "controllerwindow.h"


bool park()
{
	// ������ �ּҸ� ���ϴ� ���
	return true;
}

int main(int argc, char *argv[])
{
	QApplication app(argc, argv);

	ControllerWindow controller;			// �̹����� �߳�?


	// ����ٰ� �����
	// �ϰ� �ϴ°Ŷ� �ٸ��� ����
	// �ִٸ� ���� 3���� ����Ǹ鼭
	// �� ���� â���� �߰���

	controller.path = park();

	




	
	controller.show();









	return app.exec();
}
