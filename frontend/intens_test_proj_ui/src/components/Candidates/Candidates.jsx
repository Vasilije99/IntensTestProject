import React, { useState, useEffect } from 'react'
import { Link } from 'react-router-dom'
import backend from '../../api/backend';
import './candidates.css'

import Search from '../Search/Search';

const Candidates = () => {
    const [candidates, setCandidates] = useState([]);
    const [searchResults, setSearchResults] = useState([]);
    const [searchText, setSearchText] = useState('');
    const [searchSubmit, setSearchSubmit] = useState(false);

    const fetchCandidates = async () => {
        try {
            const response = await backend.get('/JobCandidate');
            setCandidates(response.data);
        } catch (error) {
            alert(error);
        }
    }

    const removeCandidate = async (id) => {
        try {
            await backend.delete(`/JobCandidate/removeCandidate/${id}`)
            window.confirm("Candidate was removed")
            document.location.reload(true);
        } catch (error) {
            alert(error)
        }
    }

    const searchCandidates = async (text) => {
        try {
            const response = await backend.get(`/JobCandidate/search?text=${text}`);
            setSearchResults(response.data);
            setSearchSubmit(true);
        } catch {            
            alert("There is no candidate with the entered text");
            document.location.reload(true);
        }
    }

    useEffect(() => {
        fetchCandidates();
    }, [])

    const renderedContent = searchSubmit ?
        searchResults.map((item) => {
            return (
                <tr key={item.id}>
                    <td>{item.id}</td>
                    <td className='fullname'>{item.fullName}</td>
                    <td><div className='options' onClick={() => removeCandidate(item.id)}>Remove</div></td>
                    <td><Link className='options' to={`/editCandidate/${item.id}`}>Edit</Link></td>
                    <td><Link className='options' to={`/updateSkills/${item.id}`}>Update skills</Link></td>
                </tr>
            )
        }) :
        candidates.map((item) => {
            return (
                <tr key={item.id}>
                    <td>{item.id}</td>
                    <td className='fullname'>{item.fullName}</td>
                    <td><div className='options' onClick={() => removeCandidate(item.id)}>Remove</div></td>
                    <td><Link className='options' to={`/editCandidate/${item.id}`}>Edit</Link></td>
                    <td><Link className='options' to={`/updateSkills/${item.id}`}>Update skills</Link></td>
                </tr>
            )
        })


    const handleSearchSubmit = (e) => {
        e.preventDefault();
        searchCandidates(searchText);
    }

    return (
        <div className='candidates'>
            <h3>List of job candidates:</h3>
            <Search handleSearchSubmit={handleSearchSubmit} setSearchText={setSearchText} />
            <table className="candidatesTable">
                <thead>
                    <tr>
                        <th>Candidate ID</th>
                        <th>Candidate Name</th>
                        <th colSpan={3}>Options</th>
                    </tr>
                </thead>
                <tbody>
                    {renderedContent}
                </tbody>
            </table>
        </div>
    )
}

export default Candidates