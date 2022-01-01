#include <QApplication>
#include "controllerwindow.h"


bool park()
{
	// 파일의 주소를 구하는 기능
	return true;
}

int main(int argc, char *argv[])
{
	QApplication app(argc, argv);

	ControllerWindow controller;			// 이미지가 뜨네?


	// 여기다가 만들면
	// 니가 하는거랑 다를게 없어
	// 있다면 위쪽 3줄이 실행되면서
	// 늘 보던 창들이 뜨겟지

	controller.path = park();

	




	
	controller.show();









	return app.exec();
}
