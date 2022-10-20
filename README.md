# InventoryManage 
Setup: 
1. Ensure Docker Desktop is up and running 
2. clone repo using git clone https://github.com/Terhile/Bell.git
3. Change directory to the solution root folder 
4. double click on Dockerize.sh or Dockerize.bat 
5. Navigate to http://localhost:8018/swagger/index.html to CRUD assets 
6. Navigate to http://localhost:8080/swagger/index.html to generate and view invoices 

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
  
  Generated Invoices\
  ![image](https://user-images.githubusercontent.com/37341079/196956553-f66e0ce8-40e5-438c-b4f4-18daf9d2f1f5.png)

