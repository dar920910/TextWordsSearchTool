//-----------------------------------------------------------------------
// <copyright file="DataStore.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable SA1600 // ElementsMustBeDocumented

public static class DataStore
{
    static DataStore()
    {
        ContentStringsFromTextFile = Array.Empty<string>();
    }

    public static string[] ContentStringsFromTextFile { get; set; }
}
