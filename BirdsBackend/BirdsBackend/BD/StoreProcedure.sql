CREATE OR REPLACE FUNCTION sp_getuser(userid character varying)
 RETURNS TABLE (
	"Alias" varchar,
	"Name" varchar,
	"LastName" varchar,
	"Age" varchar,
	"WasBorn" varchar,
	"DateBorn" date,
	"EmailAddress" varchar,
	"ProfilePicture" varchar,
	"AccountId" varchar,
	"DateCreate" TIMESTAMP,
	"DateClose" TIMESTAMP, 
	"IsActive" bool,
	"City" varchar,
	"Country" varchar
)
 LANGUAGE plpgsql
AS $function$
BEGIN
	
RETURN QUERY select						
    usr."Alias",  						
    usr."Name",     			
    usr."LastName",     	
    usr."Age",   			
    usr."WasBorn",     			
    usr."DateBorn",     					
    usr."EmailAddress",   					
    usr."ProfilePicture", 
	accnt."AccountId",
	accnt."DateCreate",
	accnt."DateClose", 
	accnt."IsActive",
	accnt."City",
	accnt."Country"
	
FROM "users" as usr
JOIN "account" as accnt ON usr."AccountId" = accnt."AccountId"
where 
usr."Alias" = userid;
END
$function$
;

-------------------------------------------------------------------------------------

CREATE OR REPLACE FUNCTION DeleteUserById(userId varchar, accountId varchar )
RETURNS INTEGER
AS $$
DECLARE
    success INTEGER;
BEGIN
    DELETE FROM users WHERE "Alias" = userId;
	DELETE FROM account WHERE "AccountId" = accountId;
	
    GET DIAGNOSTICS success = ROW_COUNT;
    
    RETURN success;
END;
$$ LANGUAGE plpgsql;