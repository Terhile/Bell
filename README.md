# InventoryManage
Setup:
Ensure Docker Desktop is up and running
clone repository to a folder
Change directory to the solution root foler
double click on Dockerize.sh or Dockerize.bat 
Navigate to http://localhost:8018/swagger/index.html to CRUD assets
Navigate to http://localhost:8080/swagger/index.html to generate and view invoices

Example create asset\
curl --request POST \
  --url http://localhost:8018/assets \
  --header 'Content-Type: application/json' \
  --data '{
  "name": "S3",
  "price": 10,
  "validFrom": "2021-10-20T12:48:13.832Z",
  "validTo": "2022-10-20T12:48:13.832Z"
}'

Generate Invoice Request\
curl --request POST \
  --url http://localhost:8080/invoices/2022-12-01
  
View invoices 
curl --request GET \
  --url http://localhost:8080/invoices/
  
  
  
  
  Test Asset\
  ![image](https://user-images.githubusercontent.com/37341079/196955140-fb3f7021-ee19-4f1e-a676-aa92dafa4a70.png)
