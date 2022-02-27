import React, { useState, useEffect } from 'react'
import backend from '../../api/backend';
import { useNavigate } from 'react-router';
import './updateSkills.css'

const UpdateSkills = () => {
    const id = window.location.pathname.substring(window.location.pathname.lastIndexOf('/') + 1);
    const [candidateSkills, setCandidateSkills] = useState([]);
    const [skills, setSkills] = useState([]);
    const [newSkill, setNewSkill] = useState('');

    const fetchCandidateSkills = async () => {
        try {
            const response = await backend.get(`/CandidateSkills/getCandidateSkills/${id}`)
            setCandidateSkills(response.data);
        } catch (error) {
            alert(error);
        }
    }

    const fetchSkills = async () => {
        try {
            const response = await backend.get('/Skill/getSkills')
            setSkills(response.data);
        } catch (error) {
            alert(error);
        }
    }

    const removeCandidateSkill = async (skillId) => {
        try {
            await backend.delete(`/CandidateSkills/removeSkill/${id}/${skillId}`)
            window.confirm("Candidate skill was removed")
            document.location.reload(true);
        } catch (error) {
            alert(error)
        }
    }

    const updateCandidateSkills = async () => {
        try {
            await backend.post(`/CandidateSkills/addCandidateSkill/${id}?skillId=${newSkill}`);
            window.confirm("Added a new candidate skill")
            document.location.reload(true);
        } catch (error) {
            alert(error);
        }
    }

    useEffect(() => {
        fetchCandidateSkills();
        fetchSkills();
    }, [])

    const renderedContent = candidateSkills.map((item) => {
        return (
            <li key={item.id}>
                {item.name}
                <span onClick={() => removeCandidateSkill(item.id)}>Remove</span>
            </li>
        )
    })

    const handleSubmit = (e) => {
        e.preventDefault();
        updateCandidateSkills();
    }

    return (
        <div className='candidateSkills'>
            <h3>CandidateSkills:</h3>
            <ul>
                {renderedContent}
            </ul>
            <div className='addNewSkill'>
                <h4>Add new skills:</h4>
                <form onSubmit={(e) => handleSubmit(e)}>
                    <select value={newSkill} onChange={(e) => setNewSkill(e.target.value)}>
                        {skills.map((item) => (
                            <option value={item.id} key={item.id}>{item.name}</option>
                        ))}
                    </select>
                    <button type='submit'>Submit</button>
                </form>
            </div>
        </div>
    )
}

export default UpdateSkills