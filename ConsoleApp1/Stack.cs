﻿using System.Runtime.CompilerServices;

namespace ConsoleApp1;

public class Stack
{
    private const int Capacity = 50;

    private string[] _array = new string[Capacity];

    private int _pointer;

    public void Push(string value)
    {
        if (_pointer == _array.Length)
        {
            // this code is raising an exception about reaching stack limit
            throw new Exception("Stack overflowed");
        }

        _array[_pointer] = value;
        _pointer++;
    }

    public string Pull()
    {
        if (_pointer == 0)
        {
            //you can also raise an exception here, but we're simple returning nothing
            return null;
        }

        var value = _array[_pointer];
        _pointer--;
        return value;
    }

    public string Check(string value)
    {
        for (int index = 0; index < _pointer; index++)
        {
            if (_array[index] == value)
            {
                return _array[index];
            }
        }

        return null;
    }
    
    public bool IsEmpty()
    {
        return _pointer == 0;

    }
    public string[] GetElements()
    {
        return _array;
    }
}
