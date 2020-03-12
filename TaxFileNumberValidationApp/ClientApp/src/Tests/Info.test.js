import React from 'react';
import ReactDOM from 'react-dom';
import { MemoryRouter } from 'react-router-dom';
import { Info } from '../components/Info';

it('renders without crashing', async () => {
  const div = document.createElement('div');
  ReactDOM.render(
    <MemoryRouter>
          <Info />
    </MemoryRouter>, div);
  await new Promise(resolve => setTimeout(resolve, 1000));
});

