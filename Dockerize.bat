cd AssetsManager.API
docker-compose build
docker-compose up -d

cd ..

cd Invoices.API
docker-compose build
docker-compose up -d