import React, { useState, useEffect } from 'react'
import backend from '../../api/backend';
import { useNavigate } from 'react-router';
import './editCandidate.css'

const EditCandidate = () => {
    const id = window.location.pathname.substring(window.location.pathname.lastIndexOf('/') + 1);
    const navigate = useNavigate();
    const [candidate, setCandidate] = useState(null);

    const fetchCandidate = async () => {
        try {
            const response = await backend.get(`/JobCandidate/getCandidate/${id}`)
            setCandidate(response.data);
        } catch (error) {
            alert(error);
        }
    }

    const updateCandidate = async () => {
        try {
            await backend.put(`/JobCandidate/updateCandidate/${id}`, candidate);
            window.confirm("Candidate was updated")
            navigate('/');
        } catch (error) {
            alert(error);
        }
    }

    useEffect(() => {
        fetchCandidate();
    }, [])

    const handleSubmit = (e) => {
        e.preventDefault();
        updateCandidate();
    }

    return (
        <div className="editCandidate">
            {
                candidate === null ?
                    <div className='loading'>Loading . . .</div> :
                    <form className='formTemplate' onSubmit={(e) => handleSubmit(e)}>
                        <label>
                            FullName:
                            <input type="text" value={candidate.fullName} onChange={(e) => setCandidate(prevState => ({ ...prevState, fullName: e.target.value }))} />
                        </label>
                        <label>
                            Contact Number:
                            <input type="tel" value={candidate.contactNumber} onChange={(e) => setCandidate(prevState => ({ ...prevState, contactNumber: e.target.value }))} />
                        </label>
                        <label>
                            Email:
                            <input type="text" value={candidate.email} onChange={(e) => setCandidate(prevState => ({ ...prevState, email: e.target.value }))} />
                        </label>
                        <label>
                            Date of birth:
                            <input type="date" value={candidate.dateOfBirth.substring(0, 10)} onChange={(e) => setCandidate(prevState => ({ ...prevState, dateOfBirth: e.target.value }))} />
                        </label>

                        <button type='submit'>Submit</button>
                    </form>
            }
        </div>
    )
}

export default EditCandidate