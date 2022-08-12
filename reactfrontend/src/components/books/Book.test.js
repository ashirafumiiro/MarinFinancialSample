import React from 'react'
import '@testing-library/jest-dom/extend-expect'
import { render, screen } from '@testing-library/react'
import Book from './Book'
import {BrowserRouter as Router} from 'react-router-dom'

test('Book renders content', () => {
  const book = {
    id: 1,
    title: 'Component testing done with react-testing-library',
    summary: "The test summary",
    author: {fullName: "Alex D"},
    genre:{name: 'Fantacy'}
  }

  render(<Router><Book book={book} /></Router>)

  const element = screen.getByText('Component testing done with react-testing-library')
  expect(element).toBeDefined()
})