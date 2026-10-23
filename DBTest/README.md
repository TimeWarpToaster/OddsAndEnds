
# DB Test


## Overview 

An ongoing project for a friend. DB Test combines several engines under a common ui, for basic exercise of a database environment. Currently supported, are MariaDB, MSSQL, MySQL, Postgre, and SQLite.

More specifically, this project provides working source samples, at an early attempt to build a common DB interface for C#, that operates independent of the underlying engine. Or rather, DB independent code. This has been simpler than thought in many ways, by the common manner in which each engine has chosen to implement the underlying framework. Performing a diff on the separate DB classes, will congratulate the industry on following a standard.

The provided sources are not perfect. They are merely working in a basic way, side-by-side. 

The one bug I know of, is the button to drop and recreate the test table, does not block further ui interaction while processing. In this build, the only way to know for sure that drop and recreate has completed, is to check the log tab. This is a problem mainly, because the code logic counts the table rows before and after, and the before count on a large table can take seconds or minutes to complete. If it gets in a bind because you try inserting before drop and recreate finishes, allow the table to finish being created, and click the &quot;Connect&quot; button again for the database. 


## Configuring

Core parameters are found in the App.Config file (if you are looking at sources) or in the DBTest.exe.config file (if you are looking at runables). The three options are:

### Selected DB

The database pre-selected at app launch. If the selected database also has a valid connect string, an empty test table will be created in it, with 39-fields of assorted datatypes. This test table is used to generically exercise similar behavior across databases.

### Connect String

There is a unique named key to store each database connect string independently. At-least one valid connect string is required. Only fill in engines you wish to test. App.Config represents the only place connect strings are stored outside of temporary memory. There is not an option to save connect strings from ui in this build, though they may be ui edited and restored.

### DB Name

DB name is optional for some databases and required for others (probably leaning towards required for all, as more functions are added). Some engines need a database name to query if a table or index exists. This comes down to difference in the TSQL and how the engine holds information.


## Basic Usage

Assuming a valid database connection, the app will automatically create a &quot;TestTable&quot; in the selected DB at launch or on connect, if the table does not already exist. The table can be dropped and recreated at any-time, by clicking the Drop Recreate button at bottom-left.

Insert Qty. will randomly generate row data for the 39-fields supplied by the table, and perform inserts. Work for randomizing data and querying are timed separately. This is needed, because bulk inserts are performed upto 1000-rows at a time, with intermittent generation and inserts.

Select options only work if your id values are in range. Set the minimum and maximum ID that exist in TestTable (or some valid range between). Choose how many random ids you want to query from within that range, and click select. The quantity you choose will be selected and returned from the database, but only the first 1000 rows will be displayed.

Query tab and options allow for soft-defined or dynamic SQL queries to be run ad-hoc. The routine handling this function, generally expects a tabular response that can be displayed below. However, it is possible to insert, update, drop, or run other queries from this panel. It may squawk at no response.

The DB Select tab allows switching between database engines. Sorry, there is no abundant UI feedback. The Logs tab verifies new DB is connected, test table exists, and the connection is ready to go. Clicking on a db engine, will automatically update the connect string field with whatever is stored in the config file for that database. Important:  The new database will not be connected until you click Connect. Selecting a radio button, only refreshes the connect string option, but does not change the current connection. If I make it back here, more positive connection feedback on the list.

The goal of this app, is not any particular database usage, nor to help in anyway manage a database. It is simply a generic way to load millions of randomized rows containing common datatypes, and begin outside testing with just a few clicks. Underlying benefit being, progress towards a common interface.
