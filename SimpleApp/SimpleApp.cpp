// SimpleApp.cpp : コンソール アプリケーションのエントリ ポイントを定義します。
//

#include "stdafx.h"

#include "SimpleFunctions.h"


int _tmain(int argc, _TCHAR* argv[])
{
	double result = SimpleFunctions::SimpleMath::Add(1.1, 2.2);

	printf("Hello world %f\n", result);
	return 0;
}

