#pragma once

#include <string>

#include <msclr/marshal.h>
using namespace std;
using namespace System;

void MarshalString(String^ s, string& os);
void MarshalString(String^ s, wstring& os);