// ����� ���C�� DLL �t�@�C���ł��B

#include "stdafx.h"

#include "CppCliSimpleFunctions.h"
#include "SimpleFunctions.h"

namespace CppCliSimpleFunctions{
	double SimpleMath::Add(double a, double b)
	{
		//return a + b;
		return SimpleFunctions::SimpleMath::Add(a, b);
	}
}