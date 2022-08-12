import React from 'react'
import { render, screen } from '@testing-library/react'
import '@testing-library/jest-dom/extend-expect'
import BookForm from './BookForm'
import userEvent from '@testing-library/user-event'
import test_helper from '../test_helper'

test('<BookForm /> calls onSubmit and submits sends values', async () => {
    const createBook = jest.fn()
    const user = userEvent.setup()

    render(<BookForm handleSubmit={createBook} authors={test_helper.initialAuthors} genres={test_helper.initialGenres} />)

    const input = screen.getByPlaceholderText('Title')
    const sendButton = screen.getByText('Save')

    await user.type(input, 'Testing Title')
    await user.click(sendButton)
    console.log('createBook.mock.calls[0][0]:', createBook.mock.calls[0][0])
    expect(createBook.mock.calls).toHaveLength(1)
    expect(createBook.mock.calls[0][0].content).toBe('Testing Title')
})