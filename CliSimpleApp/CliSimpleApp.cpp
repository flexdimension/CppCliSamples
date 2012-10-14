// CliSimpleApp.cpp : メイン プロジェクト ファイルです。

#include "stdafx.h"
#include "stdio.h"

using namespace System;
using namespace CliSimpleFunctions;
using namespace CppCliSimpleFunctions;

int main(array<System::String ^> ^args)
{

	double result = CliSimpleFunctions::SimpleMath::Add(1.1, 2.2);
    Console::WriteLine(L"Hello World Cli");
	Console::WriteLine(result);


	double cliResult= CppCliSimpleFunctions::SimpleMath::Add(3.3, 4.4);
	Console::WriteLine(cliResult);

	getchar();
    return 0;
}
