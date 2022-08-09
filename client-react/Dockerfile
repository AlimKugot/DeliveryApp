FROM node:18-alpine3.16
RUN npm install -g create-react-app
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build
CMD ["npm", "start"]