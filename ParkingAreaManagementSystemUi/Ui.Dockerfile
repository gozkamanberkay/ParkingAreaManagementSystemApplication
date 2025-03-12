# BUILD STAGE
FROM node:23.9.0 AS build
WORKDIR /app
COPY ./ParkingAreaManagementSystemUi/package*.json .
RUN npm install -g npm@10.9.2
RUN npm cache clean --force
RUN npm install
COPY ./ParkingAreaManagementSystemUi/ .
RUN npm run build -- --configuration=dockerCompose

FROM nginx:alpine
COPY --from=build /app/dist/parking-area-management-system/browser /usr/share/nginx/html

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]
