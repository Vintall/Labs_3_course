////#include <iostream>
////using namespace std;
////
////int main(int argc, char* argv[])
////{
////    cout << "Content - type: text / html" << endl << endl << endl;
////
////    cout << "<html><head><title>Hello!< / title>< / head><body>" << endl
////        << "Hi man!See my C++ CGI app ? !" << endl
////        << "<h1>Good!< / h1>" << endl
////        << "< / body></html>";
////    
////    return 0;
////}
//#include <iostream>
////#include <vector>
//using namespace std;
//
//int main(int argc, char* argv[])
//{
//	cout << "Content-type:text/html\r\n\r\n";
//	cout << "<html>\n";
//	cout << "<head>\n";
//	cout << "<title>Hello World - First CGI Program</title>\n";
//	cout << "</head>\n";
//	cout << "<body>\n";
//	char* s = new char();
//	//vector<char*> data = vector<char*>();
//	cin >> s;
//	//vector<char> buff = vector<char>();
//	cout << s;
//	//for (int i = 0; s[i] != ' '; i++)
//	//{
//	//	if (s[i] != '&')
//	//	{
//	//		cout << s[i];
//	//		//buff.push_back(s[i]);
//	//	}
//	//	else
//	//	{
//	//		cout << "</br>";
//	//		/*char* copy_to_pointer = new char[buff.size()];
//	//		for (int j = 0; j < buff.size(); j++)
//	//		{
//	//			copy_to_pointer[j] = buff[j];
//	//		}
//	//		data.push_back(copy_to_pointer);*/
//	//	}
//	//}
//
//	/*for (int i = 0; i < data.size(); i++)
//	{
//		cout << data[i] << "\n";
//	}*/
//	 
//	
//	//cout << "\n";
//	
//	cout << "</body>\n";
//	cout << "</html>\n";
//	return 0;
//}

#include <iostream>
#include <string>
#include <map>
#include "getpost.h"

using namespace std;

int main()
{
	map<string, string> Get;
	initializeGet(Get); //notice that the variable is passed by reference!
	cout << "Content-type: text/html" << endl << endl;
	cout << "<html><body>" << endl;

	cout << "<h1>Processing forms</h1>" << endl;
	cout << "<form method=\"get\">" << endl;
	cout << " <label for=\"fname\">First name: </label>" << endl;
	cout << " <input type=\"text\" name=\"fname\" id=\"fname\"><br>" << endl;
	cout << " <label for=\"lname\">Last name: </label>" << endl;
	cout << " <input type=\"text\" name=\"lname\" id=\"lname\"><br>" << endl;
	cout << " <input type=\"submit\" />" << endl;
	cout << "</form><br /><br />" << endl;

	if (Get.find("fname") != Get.end() && Get.find("lname") != Get.end()) {
		cout << "Hello " << Get["fname"] << " " << Get["lname"] << ", isn\'t "
			"processing CGI forms with C++ quite easy?" << endl;
	}
	else {
		cout << "Fill up the above from and press submit" << endl;
	}

	cout << "</body></html>" << endl;

	return 0;
}