#pragma once

namespace RTRM
{
	class MemoryStream
	{
	public:
		MemoryStream(void *pMem, size_t size);
		~MemoryStream();

		void Read(void *pMem, size_t len);

	private:
		char *pMemory, *pNow;

		size_t size, left;
	};
}