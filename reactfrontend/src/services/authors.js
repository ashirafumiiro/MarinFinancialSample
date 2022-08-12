import axios from 'axios'

const baseUrl = '/api/authors'

const getAll = () => {
  const request = axios.get(baseUrl)
  return request.then(response => response.data)
}

const create = newObject => {
  const request = axios.post(baseUrl, newObject)
  return request.then(response => response.data)
}

const update = (id, newObject) => {
  const request = axios.put(`${baseUrl}/${id}`, newObject)
  return request.then(response => response.data)
}

const deleteAuthor = (id) => {
  const url = `${baseUrl}/${id}`
  const request = axios.delete(url)
  return request.then(response => response)
}

const authorService = { getAll, create, update, deleteAuthor }

export default authorService