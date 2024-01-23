# LinkHub
Linkhub is a web-based platform that simplifies the process of organizing all your profile links in one centralized location. 
With Linkhub, users can easily manage and access their collection of links without the hassle of searching through multiple bookmarks or web pages. This feature-rich website provides a seamless experience for users who want to streamline their online activities and optimize their browsing efficiency.


## Features
SocialLinks
Users

## Install Dependancies

Run `npm install` for installing dependancies.

## Build

Run `npm build` to build the project.

Run `npm start` to start the server.


## Front-end [Under construction]





## Deployment

To deploy this project run

```bash
  npm run deploy
```


## Features

- Light/dark mode toggle
- Live previews
- Fullscreen mode
- Cross platform


## Installation

Install my-project with npm

```bash
  npm install my-project
  cd my-project
```
    
## Run Locally

Clone the project

```bash
  git clone https://link-to-project
```

Go to the project directory

```bash
  cd my-project
```

Install dependencies

```bash
  npm install
```

Start the server

```bash
  npm run start
```


## Usage/Examples

```javascript
import Component from 'my-project'

function App() {
  return <Component />
}
```


![Logo](https://github.com/RadwanAshraf/LinkHub/blob/main/src/assets/Images/LinkHubLogoWh.png?raw=true)


## API Reference

#### Get all items

```http
  GET /api/items
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `api_key` | `string` | **Required**. Your API key |

#### Get item

```http
  GET /api/items/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Required**. Id of item to fetch |

#### add(num1, num2)

Takes two numbers and returns the sum.

