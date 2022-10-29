#pragma once
#include <iostream>
using namespace std;
class week5
{

	int convertToBinary(int d) {
		float binary = 0;
		int b = 0;
		float pos = 10;
		int i;
		for (i = 0; i < 32 && d != 0; i++) {
			b = int(d * 2);
			binary += b / 10;
			d = d - b;
		}
		if (d != 0 && i == 32)
			throw("erorr");
		else
			return binary;

	}
	int updateBit(int num, int i, bool bitIs1)
	{
		int value = bitIs1 ? 1 : 0;
		int mask = ~(1 << i);
		return (num & mask) | (value << i);
	}
	int insertion(int n,int m, int i, int j) {
		unsigned char* b = (unsigned char*)&m;
		for (int k = 0; k < sizeof m; k++) {	
			n=updateBit(n, i, b[k]);
		}
		return n;
	}

	int main() {
		cout << insertion(52,2,3,6);
		cout<< convertToBinary(0.34);
}
};

