// vc_pscan.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "vc_pscan2.h"

#include <afxsock.h>
#include <process.h>
#include <fstream>
#include <math.h>

#pragma comment(lib,"wsock32.lib")

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// The one and only application object
//CWinApp theApp;

using namespace std;

int countOpenPort;
ofstream ofs;
char typeScan;

class CScanData
{
public:
	CString m_strErrorlog;
	CString m_strIPAddress;
	ULONG	m_IPAddress;
	UINT	m_nPortNo;
	bool	m_bOpen;
	bool	m_bFinished;
	UINT	m_count;

	CScanData()
	{ 
		//Constructor
		m_strIPAddress = "";
		m_IPAddress = 0;
		m_nPortNo = 0;
		m_strErrorlog = "";
		m_bOpen = false;
		m_bFinished = false;
		m_count = 0;
	}

	~CScanData(){;}
};

unsigned long chkIP(char* ip)
{
	unsigned long addrIP;
	addrIP = inet_addr(ip);
	in_addr addr;
	addr.S_un.S_addr = addrIP;

	int a1, a2, a3, a4;
	
	a1 = (int)addr.S_un.S_un_b.s_b1; 
	a2 = (int)addr.S_un.S_un_b.s_b2;
	a3 = (int)addr.S_un.S_un_b.s_b3;
	a4 = (int)addr.S_un.S_un_b.s_b4;
	
	unsigned long rez;
	rez = a4;
	rez += (int)(pow(2, 8.0)  * a3);
	rez += (int)(pow(2, 16.0) * a2);
	rez += (int)(pow(2, 24.0) * a1);
	
	return rez;
}


BOOL testConnection(CStringA IP, UINT nPort)
{
	//SOCK_STREAM - TCP
	//SOCK_DGRAM  - UDP
	SOCKET sock = socket(AF_INET, SOCK_STREAM, 0);

	if (sock==INVALID_SOCKET) 
		return(FALSE);
	
	SOCKADDR_IN socketaddr;
	memset(&socketaddr, 0, sizeof(socketaddr));
	socketaddr.sin_family = AF_INET;
	socketaddr.sin_addr.s_addr = inet_addr(IP); 
	socketaddr.sin_port = htons(nPort);
	int size = sizeof(socketaddr);
	sock = connect(sock, (LPSOCKADDR)&socketaddr, size);

	if (sock == SOCKET_ERROR )
		return(FALSE);

	closesocket(sock);
	return(TRUE);
}


UINT run(LPVOID pParam)
{
	CScanData *csd = (CScanData *) pParam;
	UINT port = csd->m_nPortNo;

	if (testConnection((CStringA)csd->m_strIPAddress, csd->m_nPortNo))
	{
		if(csd->m_bFinished)
			return 0;

		csd->m_bOpen = true;

		if(typeScan == 's')
		{
			cout << " \topen";
			ofs  << " \topen";
		}
		else if(typeScan == 'r')
		{
			CString str;
			str.Format(_T(" Port %d\topen"), port);
			cout << endl << str;
			ofs  << endl << str;
		}
	}
	
	countOpenPort++;

	csd->m_bFinished = true;
	csd = NULL;

	AfxEndThread(0);
	
	return 0;
}


int _tmain(int argc, TCHAR* argv[], TCHAR* envp[])
{
	CTime time;

	//if(argc < 6)
	//{
	//	cout << "Error parameters!" << endl;
	//	cout << "List parameters:" << endl;
	//	cout << "  1. IP address beg" << endl;
	//	cout << "  2. IP address end" << endl;
	//	cout << "  3. Begin port number" << endl;
	//	cout << "  4. End port number" << endl;
	//	cout << "  5. Timing (mc)" << endl;
	//	return 1;
	//}
	
	time = CTime::GetCurrentTime();
	CStringA str = "vc_pscan_";
	str += time.Format("%Y-%m-%d");
	str += "_";
	str += time.Format("%H-%M-%S");
	str += ".log";
	ofs.open(str);
		
	cout << endl << "scanning network port(TCP) utility 1.0.0" << endl;
	cout << endl << " DateTime: " << (CStringA)time.Format("%d.%m.%Y") << " " << (CStringA)time.Format("%H:%M:%S") << endl;
	ofs  << endl << "scanning network port(TCP) utility 1.0.0" << endl;
	ofs << endl << " DateTime: " << (CStringA)time.Format("%d.%m.%Y") << " " << (CStringA)time.Format("%H:%M:%S") << endl;

	in_addr addr;
	addr.S_un.S_addr = inet_addr("127.0.0.1");

	char* p1 = (char*)argv[1];
	char tmp = p1[0];
	typeScan = tmp;

	int m    = 0;
	int rez  = 0;

	unsigned long addrBegChk = chkIP((char*)argv[2]);
	unsigned long addrEndChk = chkIP((char*)argv[3]);
	unsigned long scanIP = inet_addr((CStringA)argv[2]);

	int portBeg = 0;
	int portEnd = 0;
	int timing  = 0;

	cout << endl << "Scanning parameters" << endl; 
	cout << endl << "Begin ip:" << (CStringA)argv[2] << "  end ip:" << (CStringA)argv[3] << endl;
	ofs  << endl << "Scanning parameters" << endl;
	ofs << endl << "Begin ip:" << (CStringA)argv[2] << "  end ip:" << (CStringA)argv[3] << endl;

	if(tmp == 's')
	{
		timing = atoi((CStringA)argv[4]);
		cout << " timing:" << timing << "ms";
		ofs  << " timing:" << timing << "ms";

	}
	else if(tmp == 'r')
	{
		portBeg = atoi((CStringA)argv[4]);
		portEnd = atoi((CStringA)argv[5]);
		timing = atoi((CStringA)argv[6]);

		cout << " begin port:" << portBeg << "  end port:" << portEnd << "  timing:" << timing << "ms";
		ofs  << " begin port:" << portBeg << "  end port:" << portEnd << "  timing:" << timing << "ms";
	}

	unsigned long n = addrBegChk;
	while(n <= addrEndChk)
	{
		WSADATA wsaData;
		WSAStartup(WINSOCK_VERSION, &wsaData); 

		countOpenPort = 0;

		if((int)addr.S_un.S_un_b.s_b4 == 255)
		{
			m += 256;
			++rez;
		}

		addr.S_un.S_addr = scanIP;
		addr.S_un.S_un_b.s_b3 = addr.S_un.S_un_b.s_b3 + rez;
		addr.S_un.S_un_w.s_w2 = addr.S_un.S_un_w.s_w2 + (256*m);
	    
		char* ipChk =  inet_ntoa(addr);
		
		cout << endl << endl << "Host:" << ipChk;
		ofs  << endl << endl << "Host:" << ipChk;

		DWORD time = GetTickCount();

		if(tmp == 's')
		{
			/*******************************************************************************
			FTP/file server open/vulnerable (port 21)  	
			TELNET service open/vulnerable(port 23)
			SMPT relay vulnerable (port 25)
			HTTP/web server vulnerable (port 80)
			POP3/mail server vulnerable (port 110)
 			Scan for NETBIOS susceptibility (port 139) 	
			Scan for Windows file sharing susceptibility (port 445)
			Microsoft SQL Server open/vulnerable (port 1433)
			Oracle database service open/vulnerable (port 1521)
			VPN (PPTP) service open/vulnerable (port 1723)
			MySQL database open/vulnerable (port 3306)
			Microsoft Remote Desktop vulnerable (port 3389) 	
			VNC Remote Desktop vulnerable (port 5900)
			Scan for firewall remote login (port 8080)
			*******************************************************************************/

			int pr[] = {21, 23, 25, 80, 110, 139, 445, 1433, 1521, 1723, 3389, 8080}; 

			CStringA st[] = 
			{
				"Port 21",
				"Port 23",
				"Port 25",
				"Port 80",
				"Port 110",
				"Port 139",
				"Port 445",
				"Port 1433",
				"Port 1521",
				"Port 1723",
				"Port 3389",
				"Port 8080"
			};


			for(int i = 0; i < 12; i++)
			{
				CStringA s = st[i];
				CScanData* pScanData = new CScanData();
				pScanData->m_strIPAddress = ipChk;
				pScanData->m_nPortNo = pr[i];
				//Sleep(timing);
				cout << endl << " " << s;
				ofs << endl << " " << s;
				AfxBeginThread(run, (void*) pScanData, THREAD_PRIORITY_NORMAL);
				Sleep(timing);
				pScanData = NULL;			
				delete pScanData;
			}
		}
		else if(tmp == 'r')
		{
			for(int i = portBeg; i <= portEnd; i++)
			{
				CScanData* pScanData = new CScanData();
				pScanData->m_strIPAddress = ipChk;
				pScanData->m_nPortNo = i;
				Sleep(timing);
				AfxBeginThread(run, (void*) pScanData, THREAD_PRIORITY_NORMAL);
				pScanData = NULL;			
				delete pScanData;
			}	
		}

		cout << endl << "--------------------------------------------------";
		ofs  << endl << "--------------------------------------------------";
		
		if(countOpenPort > 0)
		{
			cout << endl <<" Scanning ready "; 
			ofs  << endl <<" Scanning ready ";
			
			time = GetTickCount() - time;
			CStringA str;
			str.Format("  Time scanning:%isec ", time/1000);
			cout << endl << str;
			ofs  << endl << str;
		}
		else
		{
			cout << endl << " Not found open ports";
			ofs  << endl << " Not found open ports";
		}

		cout << endl <<" Scanning ready "; 
		ofs  << endl <<" Scanning ready ";

		m++;
		n++;
		
		WSACleanup();
	}

	time = CTime::GetCurrentTime();
	cout << endl << "==================================================";
	cout << endl << "End scanning. DateTime: " << (CStringA)time.Format("%d.%m.%Y") << " " << (CStringA)time.Format("%H:%M:%S") << endl << endl;
	ofs  << endl << "==================================================";
	ofs << endl << "End scanning. DateTime: " << (CStringA)time.Format("%d.%m.%Y") << " " << (CStringA)time.Format("%H:%M:%S") << endl << endl;

	ofs.close();
	
	ExitThread(0);	
		
	return 0;
}