#include "StdAfx.h"
#include "IldasmString.h"

#include <stdio.h>

#include <stdlib.h>

#include <string.h>

#using <mscorlib.dll>

using namespace System;  

public __gc class IldasmString
{
	public: String * ReturnStringForR4(float e)
    {
		char szf[32],*pch;

		gcvt(e , 8 , szf);

		float  df = atof(szf );

		char *s = strchr(szf , '.');

		int result = (int) ( s - szf);

		String *ss ;

		ss = szf;

		if ( (strlen(szf) - result ) == 1&&  e <= 9999999)
			return ss;
		else if ( strchr(szf,'.') == 0)
			return ss;
		else
			ss = "" ;

		return ss; 
    }

    public: String * ReturnStringForR8(double e, int j)
    {
		char szprt[1000];

		char szf[32],*pch;

		gcvt(e , 17 , szf);

		double df = strtod(szf , &pch);

		if ( j == 0)
			sprintf ( szprt , "%s", szf);
		else if ( df == e )
			sprintf ( szprt , "%s)", szf);
		else
			sprintf ( szprt , "0x%I64X) // %s", e , szf);

		String *ss = szprt;

		return ss;
 
    }

};

