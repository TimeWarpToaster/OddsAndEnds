
# Postgre Testing

This project is for a friend, who was interesting how compatible Postgre is with C# .NET, and what kind of loads it could handle. The interface is minimal, with limited functionality, and depends upon a Postgre SQL 18 database existing to connect to. Set connection parameters at the top of TestHelpers class, about a quarter of the way down TestTable.cs when testing. 

Provided sources are mainly for loading junk-data, testing Postgre DB Functions (used as stored-procedures), and running soft entered queries that return tabular results. Included, is a generic C# function (TestHelpers.query) to accept either Function or dynamic SQL, automatically prepare parameters in the case of using a Function, and return a generic List\<Dictionary\<string, object\>\> of row data to caller. NOTE: This is a test-harness, scrap-code, for basic illustration of function only.

At the bottom of this document, are create scripts for the table, and a function to retrieve N-rows complete. 

Datatypes tested are:<br /><br />
Bigserial (auto-increment long)<br />
Integer<br />
Bigint<br />
Real (float)<br />
Double precision<br />
Boolean<br />
Bit (as bit(1) / converted to bool in code)<br />
Character varying<br />
Timestamp<br />
Timestamptz<br />


# Options

Insert - Accepts a number of rows to create, mocks-up row data, and performs a bulk insert. Regardless of how many rows are requested, they will be generated and added upto 1000 rows at a time until complete. For quantity less than 1-million rows, time is short. For 100-million rows (around 60-70GB), it may take a few hours to generate and insert data. 

Select - Accepts a start id (of data in the table), max id, and quantity to select. Generates a list of random numbers between min and max, then performs select. UI will only display the first 1000 rows returned, in a very scrappy HTML table. More-or-less depends upon contiguous data/ids between min and max (tries to count and validate all rows returned). Select queries are run one-by-one (id-based), within a transaction.

Use DB Function - Applies to bulk insert and select options above. Either uses the DB Function / SP, or uses dynamic SQL instead. 

Query - Allows entering a query to run dynamically. These are typically basic select queries. Results will only be displayed, if the query returns tabular data that can be pulled off the cursor in a generic manner. 

Note: the rows label does not update, artifact. Instead, the results table is prefixed with a row-count and time consumed by query, sans-formatting for ui and any time used to create random input.


# Postgre Scripts

These were created using pgAdmin 4 and Postgre SQL 18

## Table Create

<pre>
-- Table: public.testtable

-- DROP TABLE IF EXISTS public.testtable;

CREATE TABLE IF NOT EXISTS public.testtable
(
    testid bigserial NOT NULL,
    cdt timestamp with time zone NOT NULL DEFAULT now(),
    fid1 bigint,
    fid2 bigint,
    fid3 bigint,
    "Label" character varying(40) COLLATE pg_catalog."default",
    unitnum character varying(40) COLLATE pg_catalog."default",
    serialnum character varying(40) COLLATE pg_catalog."default",
    mfrid bigint,
    mfrlocid integer,
    machineid integer,
    lot integer,
    mfrdate timestamp with time zone,
    instdate timestamp with time zone,
    instaddr1 character varying(40) COLLATE pg_catalog."default",
    instaddr2 character varying(40) COLLATE pg_catalog."default",
    instcity character varying(20) COLLATE pg_catalog."default",
    instcounty character varying(20) COLLATE pg_catalog."default",
    instprovince character varying(20) COLLATE pg_catalog."default",
    inststate character varying(20) COLLATE pg_catalog."default",
    instcountry character varying(20) COLLATE pg_catalog."default",
    lastchecked timestamp with time zone,
    lastmodified timestamp with time zone,
    lastreplaced timestamp with time zone,
    lasttechid bigint,
    billingdate timestamp without time zone,
    lastbillingdate timestamp without time zone,
    due real,
    pastdue real,
    lastdue real,
    something double precision,
    isactive boolean,
    isonline bit(1),
    lastoffline timestamp with time zone,
    failedmessages bigint,
    lastactioncode character varying(4) COLLATE pg_catalog."default",
    lastaction character varying(40) COLLATE pg_catalog."default",
    nextactioncode character varying(4) COLLATE pg_catalog."default",
    nexttechid bigint,
    cntactionstaken integer,
    lastnote text COLLATE pg_catalog."default",
    CONSTRAINT testtable_pkey PRIMARY KEY (testid)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.testtable
    OWNER to postgres;
-- Index: idx_testtable_idcdt

-- DROP INDEX IF EXISTS public.idx_testtable_idcdt;

CREATE INDEX IF NOT EXISTS idx_testtable_idcdt
    ON public.testtable USING btree
    (cdt ASC NULLS LAST);

-- Index: idx_testtable_testid

-- DROP INDEX IF EXISTS public.idx_testtable_testid;

CREATE INDEX IF NOT EXISTS idx_testtable_testid
    ON public.testtable USING btree
    (testid ASC NULLS LAST);
</pre>


## Function: Select By ID Field

<pre>
-- FUNCTION: public.gettesttablebyid(bigint)

-- DROP FUNCTION IF EXISTS public.gettesttablebyid(bigint);

CREATE OR REPLACE FUNCTION public.gettesttablebyid(
	ptestid bigint)
    RETURNS TABLE
(
    testid bigint, 
    cdt timestamp with time zone, 
    fid1 bigint, 
    fid2 bigint, 
    fid3 bigint, 
    "Label" character varying, 
    unitnum character varying, 
    serialnum character varying, 
    mfrid bigint, 
    mfrlocid integer, 
    machineid integer, 
    lot integer, 
    mfrdate timestamp with time zone, 
    instdate timestamp with time zone, 
    instaddr1 character varying, 
    instaddr2 character varying, 
    instcity character varying, 
    instcounty character varying, 
    instprovince character varying, 
    inststate character varying, 
    instcountry character varying, 
    lastchecked timestamp with time zone, 
    lastmodified timestamp with time zone, 
    lastreplaced timestamp with time zone, 
    lasttechid bigint, 
    billingdate timestamp without time zone, 
    lastbillingdate timestamp without time zone, 
    due real, 
    pastdue real, 
    lastdue real, 
    something double precision, 
    isactive boolean, 
    isonline bit, 
    lastoffline timestamp with time zone, 
    failedmessages bigint, 
    lastactioncode character varying, 
    lastaction character varying, 
    nextactioncode character varying, 
    nexttechid bigint, 
    cntactionstaken integer, 
    lastnote text
  ) 
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$

begin

RETURN QUERY
--Where clause fields must be prefixed with table name, to prevent
--ambiguous field name error in result.
select * from TestTable where TestTable.TestId=pTestId;
end;
$BODY$;

ALTER FUNCTION public.gettesttablebyid(bigint)
    OWNER TO postgres;
</pre>


## Get DB Size on Disk (seems accurate)

select pg_size_pretty(pg_database_size('DbName'));




