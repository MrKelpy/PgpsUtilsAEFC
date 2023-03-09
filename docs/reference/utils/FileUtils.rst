FileUtils
=========
| ``public static utils.FileUtils``
| 	This singleton internal class implements a cache that stores every control's original parent, so that the dynamic loading/unloading of active components can be managed smoothly.

---------

Method Implementations
~~~~~~~~~~~~~~~~~~~~~~
.. 

---------

.. code-block:: cs

	public static void DumpToFile(string path, List<string> data)
	
| Writes all the given data in bulk to the specified filepath.

:parameters:	* <string> path - The filepath to dump the data into.
				* <List<string>> data - A List containing the lines to write into the file.
				
---------

.. code-block:: cs

	public static void AppendToFile(string path, string data)
	
| Appends a given line to the end of the file.

:parameters:	* <string> path - The filepath to dump the data into.
				* <string> data - A string containing the line to write into the file.
				
---------

.. code-block:: cs

	public static List<string> ReadFromFile(string path)
	
| Reads all the lines from a file and returns them in the form of a list.

:parameters:	* <string> path - The filepath to dump the data into.
				
:returns: <List<string>> A list containing all the lines in the file

---------

.. code-block:: cs

	public static List<string> ReadFromFile(string path)
	
| Reads all the lines from a file and returns them in the form of a list.

:parameters:	* <string> path - The filepath to dump the data into.
				
:returns: <List<string>> A list containing all the lines in the file

---------

.. code-block:: cs

	public static void DumpToFileBinary(string path, List<string> data)
	
| Writes all the given data in bulk, as binary information, into the specified filepath.

:parameters:	* <string> path - The filepath to dump the data into.
				* <List<string>> data - The primitive values to write into the file.

---------

.. code-block:: cs

	public static List<string> ReadFromFileBinary(string path)
	
| Reads the data in the specified filepath and returns it in the form of a list with 	all the values as strings.

:parameters:	* <string> path - The filepath to dump the data into.
:returns: <List<string>> The primitive values in a list of strings