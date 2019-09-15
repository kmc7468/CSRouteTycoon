#include "Stdafx.h"
#include "MemoryStream.h"

#include <memory.h>

namespace RTRM
{
	MemoryStream::MemoryStream(void *pMem, size_t len)
	{
		pMemory = pNow = (char *)pMem;
		size = left = len;
	}

	MemoryStream::~MemoryStream()
	{
	}

	void MemoryStream::Read(void *pMem, size_t len)
	{
		size_t nLeft = left;

		if (nLeft < len)
			return;

		left = nLeft - len;
		memcpy(pMem, pNow, len);
		pNow += len;
	}
}