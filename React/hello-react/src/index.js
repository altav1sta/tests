import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';

function Hello() {
  return <h1>Welcome to React</h1>;
}

ReactDOM.render(
  <Hello />,
  document.getElementById('root')
);