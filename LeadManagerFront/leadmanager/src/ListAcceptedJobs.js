import React, { useState, useEffect } from "react";
import { apiClient } from "./ApiClient";

export function ListAcceptedJobs() {
    const [jobs, setJobs] = useState([]);
    const [loading, setLoading] = useState(true)

    useEffect(() => {
        const fetchJobs = async () => {
            try {
                const response = await apiClient('Job?leadStatus=2');
                setJobs(response.data);
            } catch (error) {
                console.error("There was an error fetching the jobs!", error);
            } finally {
                setLoading(false);
            }};

        fetchJobs();
    }, []);

    if (loading)
        return <div> Carregando... </div>
    else {
        return (
            <div>
                {jobs.map((job, index) => (
                    <div key={index} className="flex flex-col gap-2 grow">
                        <div className="flex justify-between items-center">
                            <h3 className="text-neutral-900"> {job.lead.contactFirstName} </h3>
                            <p className="text-sm text-neutral-500"> {job.jobDate} </p>
                        </div>
                        <div className="flex items-center gap-2 text-neutral-500">
                            <span className="material-symbols-outlined">location_on</span>
                            <span> {job.lead.suburb} </span>
                            <span className="material-symbols-outlined">business</span>
                            <span> {job.jobCategory} </span>
                            <span>Job ID: {job.jobID} </span>
                            <span>${job.jobPrice} Lead Invitation</span>
                        </div>
                        <p className="text-orange-600 flex items-center gap-2">
                            <span className="material-symbols-outlined">phone</span>
                            <span> {job.lead.contactPhoneNumber} </span>
                            <span className="material-symbols-outlined">mail</span>
                            <span> {job.lead.contactEmail} </span>
                        </p>
                        <p className="text-neutral-500"> {job.JobDescription} </p>
                    </div>
                ))}
            </div>
        )
    }
}