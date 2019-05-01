// main.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
#include <iostream>
#include "UnionFindTestHelper.h"


int main()
{
	int n = 5000000;
	//UnionFindTestHelper::testUF1(n);
	//UnionFindTestHelper::testUF2(n);
	UnionFindTestHelper::testUF3(n);
	UnionFindTestHelper::testUF4(n);
	UnionFindTestHelper::testUF5(n);

	return 0;
}

