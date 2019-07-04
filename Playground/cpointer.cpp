#include <iostream>
using namespace std;

int get(int *n){
return *n +1;
}

int main()
{
	
   cout << "Hello World";
	int avalue=5;
	int *aaddr=&avalue;
	cout<< get(aaddr);
	cout << "yes ok";
   return 0;
}
