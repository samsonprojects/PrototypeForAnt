Summary:
This exercise concentrates on a specific section of these documents known as the “Schedule of notices of leases” which outlines all of the sub-leases associated with the parent Title. The schedule is set out in a tabular format within the PDF document but is returned in a lossy format through the API so in order to make use of the content, we need to reconstitute the tabular structure. 


Plan:

create API project
getJsonResponse
Deserialize JsonResponse to LeaseScheduleObject
Validate the Schedule Entry within the LeaseScheduleObject is valid
Create a schedule of notices of leasees object to represent the data for easier
mapping purposes

Creating A DataTransformationService to parse the data
it expects a LeaseScheduleObject
returns ScheduleOfNoticesOfLeases
parsed into a collection of dictionaries
which is a Dictionary<columnName,[strings]>



Create a service 
Method to Parse Entry text column
transform columns into data points, create a class to represent the data
class EntryText
has a List<EntryTextData> which has the below
list< class EntryTextItems>
string note


Search by Column

Registration date and plan ref,Property description,Date of lease and term,Lessee’s title

http://localhost:8080/api/ScheduleOfNoticeLeases/1/columnname?


Challenge:
Using whatever approach you see fit, prototype a solution for structuring the Schedule of notices of lease data so that the column data and optional notes can be referenced independently.
