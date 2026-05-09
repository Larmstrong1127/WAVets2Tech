import React, { useState } from 'react';

// ── Mock data ──────────────────────────────────────────────────
const MOCK_COMPANIES = [
  { id: 1, companyName: 'Microsoft',        email: 'hiring@microsoft.com',   phone: '(425) 882-8080' },
  { id: 2, companyName: 'Amazon',           email: 'recruiting@amazon.com',  phone: '(206) 266-1000' },
  { id: 3, companyName: 'Boeing',           email: 'careers@boeing.com',     phone: '(312) 544-2000' },
  { id: 4, companyName: 'SAIC',             email: 'talent@saic.com',        phone: '(703) 676-4300' },
  { id: 5, companyName: 'Leidos',           email: 'jobs@leidos.com',        phone: '(571) 526-6000' },
  { id: 6, companyName: 'T-Mobile',         email: 'careers@t-mobile.com',   phone: '(425) 378-4000' },
  { id: 7, companyName: 'Accenture',        email: 'recruiting@accenture.com',phone: '(206) 839-5000' },
  { id: 8, companyName: 'Comcast',          email: 'hiring@comcast.com',     phone: '(215) 286-1700' },
];

const MOCK_JOBS = [
  { id: 1, title: 'Software Engineer',        company: 'Microsoft',  location: 'Redmond, WA',  category: 'Engineering',      salary: '$110k–$150k' },
  { id: 2, title: 'DevOps Engineer',          company: 'Amazon',     location: 'Seattle, WA',  category: 'Engineering',      salary: '$120k–$160k' },
  { id: 3, title: 'Cybersecurity Analyst',    company: 'SAIC',       location: 'Tacoma, WA',   category: 'Cybersecurity',    salary: '$90k–$120k'  },
  { id: 4, title: 'Data Analyst',             company: 'Boeing',     location: 'Renton, WA',   category: 'Data & Analytics', salary: '$85k–$110k'  },
  { id: 5, title: 'IT Systems Administrator', company: 'Leidos',     location: 'Olympia, WA',  category: 'IT Operations',    salary: '$75k–$100k'  },
  { id: 6, title: 'Full Stack Developer',     company: 'Accenture',  location: 'Bellevue, WA', category: 'Engineering',      salary: '$100k–$140k' },
  { id: 7, title: 'Cloud Architect',          company: 'T-Mobile',   location: 'Bellevue, WA', category: 'Engineering',      salary: '$130k–$170k' },
  { id: 8, title: 'Network Engineer',         company: 'Comcast',    location: 'Lynnwood, WA', category: 'IT Operations',    salary: '$80k–$110k'  },
];

const MOCK_VETERANS = [
  { id: 1, name: 'John Martinez',   branch: 'Army',        program: 'Software Development', status: 'Available' },
  { id: 2, name: 'Sarah Johnson',   branch: 'Navy',        program: 'Cybersecurity',        status: 'Available' },
  { id: 3, name: 'Michael Davis',   branch: 'Marine Corps',program: 'Data Science',         status: 'Interviewing' },
  { id: 4, name: 'Amanda Torres',   branch: 'Air Force',   program: 'Cloud Computing',      status: 'Available' },
  { id: 5, name: 'Ryan Thompson',   branch: 'Army',        program: 'Network Engineering',  status: 'Available' },
  { id: 6, name: 'Jessica Williams',branch: 'Coast Guard', program: 'Software Development', status: 'Placed' },
];

const JOB_CATEGORIES = ['All Categories', 'Engineering', 'Cybersecurity', 'Data & Analytics', 'IT Operations'];
const BRANCHES = ['All Branches', 'Army', 'Navy', 'Marine Corps', 'Air Force', 'Coast Guard'];

// ── Colour tokens — Saint Martin's University (red · gray · black)
const C = {
  navBg:    '#111111',
  heroBg:   'linear-gradient(135deg,#8b0000 0%,#c8102e 60%,#e8182e 100%)',
  accent:   '#c8102e',
  accentLt: '#f4a0aa',
  white:    '#ffffff',
  gray50:   '#f5f5f5',
  gray100:  '#ebebeb',
  gray200:  '#d6d6d6',
  gray500:  '#6b6b6b',
  gray700:  '#3a3a3a',
  gray900:  '#111111',
  green:    '#22c55e',
  yellow:   '#f59e0b',
};

// ── Reusable styles ─────────────────────────────────────────────
const S = {
  navbar:    { background: C.navBg, padding: '0.75rem 2rem', display: 'flex', alignItems: 'center', justifyContent: 'space-between', boxShadow: '0 2px 8px rgba(0,0,0,.5)', borderBottom: '3px solid #c8102e', position: 'sticky', top: 0, zIndex: 100 },
  brand:     { color: C.white, fontSize: '1.4rem', fontWeight: 800, margin: 0, cursor: 'pointer', letterSpacing: '-0.3px' },
  navList:   { display: 'flex', gap: '0.25rem', listStyle: 'none', margin: 0, padding: 0 },
  navBtn:    (active) => ({ background: active ? '#c8102e' : 'transparent', color: C.white, border: active ? 'none' : '1px solid rgba(255,255,255,.15)', borderRadius: 6, padding: '0.4rem 0.9rem', fontWeight: 500, cursor: 'pointer', fontSize: '0.95rem', transition: 'all .15s' }),
  page:      { fontFamily: "'Segoe UI',Tahoma,Geneva,Verdana,sans-serif", background: C.gray50, minHeight: '100vh', color: C.gray700 },
  hero:      { background: C.heroBg, color: C.white, padding: '4rem 2rem', textAlign: 'center' },
  heroTitle: { fontSize: '2.5rem', fontWeight: 800, margin: '0 0 0.75rem' },
  heroSub:   { color: 'rgba(255,255,255,0.85)', fontSize: '1.05rem', maxWidth: 560, margin: '0 auto 2rem' },
  badge:     { display: 'inline-block', background: 'rgba(0,0,0,.25)', border: '1px solid rgba(255,255,255,.3)', borderRadius: 999, padding: '0.25rem 1rem', fontSize: '0.8rem', marginBottom: '1rem', letterSpacing: '0.5px' },
  ctaRow:    { display: 'flex', gap: '1rem', justifyContent: 'center', flexWrap: 'wrap', marginTop: '1.5rem' },
  btnPrimary:{ background: C.white, color: C.accent, border: 'none', borderRadius: 8, padding: '0.65rem 1.5rem', fontWeight: 700, cursor: 'pointer', fontSize: '0.95rem' },
  btnOutline:{ background: 'transparent', color: C.white, border: '2px solid rgba(255,255,255,.6)', borderRadius: 8, padding: '0.65rem 1.5rem', fontWeight: 600, cursor: 'pointer', fontSize: '0.95rem' },
  container: { maxWidth: 1100, margin: '0 auto', padding: '2rem 1rem' },
  sectionH:  { fontSize: '1.5rem', fontWeight: 700, marginBottom: '0.25rem', color: C.gray900, borderLeft: '4px solid #c8102e', paddingLeft: '0.6rem' },
  sectionSub:{ color: C.gray500, fontSize: '0.9rem', marginBottom: '1.5rem', paddingLeft: '0.85rem' },
  filterBar: { display: 'flex', gap: '0.75rem', flexWrap: 'wrap', marginBottom: '1.5rem' },
  input:     { flex: 1, minWidth: 180, padding: '0.55rem 0.9rem', border: `1px solid ${C.gray200}`, borderRadius: 6, fontSize: '0.9rem', color: C.gray700, background: C.white },
  select:    { padding: '0.55rem 0.9rem', border: `1px solid ${C.gray200}`, borderRadius: 6, fontSize: '0.9rem', color: C.gray700, background: C.white },
  grid:      { display: 'grid', gridTemplateColumns: 'repeat(auto-fill,minmax(300px,1fr))', gap: '1rem' },
  card:      { background: C.white, border: `1px solid ${C.gray200}`, borderTop: '3px solid #c8102e', borderRadius: 6, padding: '1.25rem', boxShadow: '0 1px 4px rgba(0,0,0,.06)', transition: 'box-shadow .2s' },
  cardTitle: { fontWeight: 700, fontSize: '1rem', color: C.gray900, marginBottom: '0.2rem' },
  cardSub:   { color: C.accent, fontSize: '0.85rem', fontWeight: 600, marginBottom: '0.15rem' },
  cardMeta:  { color: C.gray500, fontSize: '0.82rem', marginBottom: '0.15rem' },
  pill:      (color='#fde8eb',text='#c8102e') => ({ display: 'inline-block', background: color, color: text, borderRadius: 999, padding: '0.15rem 0.65rem', fontSize: '0.75rem', fontWeight: 600, marginTop: '0.5rem' }),
  statBox:   { background: C.white, border: `1px solid ${C.gray200}`, borderRadius: 6, padding: '1.5rem', textAlign: 'center', boxShadow: '0 1px 4px rgba(0,0,0,.06)' },
  footer:    { background: '#111111', color: 'rgba(255,255,255,0.5)', textAlign: 'center', padding: '1.5rem', marginTop: '3rem', fontSize: '0.875rem', borderTop: '3px solid #c8102e' },
};

// ── Sub-pages ───────────────────────────────────────────────────
const HomePage = ({ onNavigate, totalJobs, totalVets, totalCompanies }) => (
  <>
    <section style={S.hero}>
      <div style={S.badge}>🎖 Connecting Veterans with Tech Careers</div>
      <h2 style={S.heroTitle}>Your Service. Your Future.</h2>
      <p style={S.heroSub}>
        WAVets2Tech bridges the gap between Washington state military veterans
        and technology employers. Find your next career today.
      </p>
      <div style={S.ctaRow}>
        <button style={S.btnPrimary} onClick={() => onNavigate('jobs')}>Browse Jobs</button>
        <button style={S.btnOutline} onClick={() => onNavigate('veterans')}>Meet Veterans</button>
      </div>
    </section>

    <div style={S.container}>
      <div style={{ display: 'grid', gridTemplateColumns: 'repeat(auto-fill,minmax(200px,1fr))', gap: '1rem', marginBottom: '2.5rem' }}>
        {[
          { icon: '💼', value: totalJobs,      label: 'Open Positions' },
          { icon: '🎖',  value: totalVets,      label: 'Veteran Students' },
          { icon: '🏢', value: totalCompanies, label: 'Partner Employers' },
        ].map(stat => (
          <div key={stat.label} style={S.statBox}>
            <div style={{ fontSize: '2rem', marginBottom: '0.5rem' }}>{stat.icon}</div>
            <div style={{ fontSize: '2rem', fontWeight: 800, color: C.gray900 }}>{stat.value}</div>
            <div style={{ color: C.gray500, fontSize: '0.9rem' }}>{stat.label}</div>
          </div>
        ))}
      </div>

      <h2 style={S.sectionH}>Why WAVets2Tech?</h2>
      <p style={{ ...S.sectionSub, marginBottom: '1rem' }}>
        Veterans bring discipline, leadership, and mission-focused thinking — qualities the tech industry values.
        We help translate that experience into a career you've earned.
      </p>
      <div style={{ display: 'grid', gridTemplateColumns: 'repeat(auto-fill,minmax(240px,1fr))', gap: '1rem' }}>
        {[
          { icon: '🎯', title: 'Targeted Jobs', body: 'Curated listings from employers who actively seek veteran talent.' },
          { icon: '📋', title: 'Profile Builder', body: 'Showcase your military background, clearances, and certifications.' },
          { icon: '🤝', title: 'Direct Connect', body: 'Employers can search and bookmark veteran profiles directly.' },
        ].map(f => (
          <div key={f.title} style={S.card}>
            <div style={{ fontSize: '1.75rem', marginBottom: '0.5rem' }}>{f.icon}</div>
            <div style={S.cardTitle}>{f.title}</div>
            <p style={{ color: C.gray500, fontSize: '0.875rem', margin: 0 }}>{f.body}</p>
          </div>
        ))}
      </div>
    </div>
  </>
);

const JobsPage = () => {
  const [search, setSearch]     = useState('');
  const [category, setCategory] = useState('All Categories');
  const [location, setLocation] = useState('');

  const filtered = MOCK_JOBS.filter(j =>
    j.title.toLowerCase().includes(search.toLowerCase()) &&
    (category === 'All Categories' || j.category === category) &&
    j.location.toLowerCase().includes(location.toLowerCase())
  );

  return (
    <div style={S.container}>
      <h2 style={S.sectionH}>Open Positions</h2>
      <p style={S.sectionSub}>Tech jobs from employers actively hiring veterans</p>

      <div style={S.filterBar}>
        <input style={S.input} placeholder="Search job title..." value={search} onChange={e => setSearch(e.target.value)} />
        <select style={S.select} value={category} onChange={e => setCategory(e.target.value)}>
          {JOB_CATEGORIES.map(c => <option key={c}>{c}</option>)}
        </select>
        <input style={{ ...S.input, flex: '0 0 160px' }} placeholder="Location..." value={location} onChange={e => setLocation(e.target.value)} />
      </div>

      {filtered.length === 0 ? (
        <p style={{ color: C.gray500, textAlign: 'center', padding: '2rem' }}>No jobs match your search.</p>
      ) : (
        <div style={S.grid}>
          {filtered.map(job => (
            <div key={job.id} style={S.card}>
              <div style={S.cardTitle}>{job.title}</div>
              <div style={S.cardSub}>{job.company}</div>
              <div style={S.cardMeta}>📍 {job.location}</div>
              <div style={S.cardMeta}>💰 {job.salary}</div>
              <span style={S.pill()}>{job.category}</span>
            </div>
          ))}
        </div>
      )}
      <p style={{ color: C.gray500, fontSize: '0.82rem', marginTop: '1rem' }}>
        Showing {filtered.length} of {MOCK_JOBS.length} positions
      </p>
    </div>
  );
};

const VeteransPage = () => {
  const [search, setSearch] = useState('');
  const [branch, setBranch] = useState('All Branches');

  const statusColor = s => s === 'Available' ? ['#dcfce7','#16a34a'] : s === 'Interviewing' ? ['#fef9c3','#ca8a04'] : ['#fde8eb','#c8102e'];

  const filtered = MOCK_VETERANS.filter(v =>
    v.name.toLowerCase().includes(search.toLowerCase()) &&
    (branch === 'All Branches' || v.branch === branch)
  );

  return (
    <div style={S.container}>
      <h2 style={S.sectionH}>Veteran Students</h2>
      <p style={S.sectionSub}>Talented veterans completing tech training programs</p>

      <div style={S.filterBar}>
        <input style={S.input} placeholder="Search by name..." value={search} onChange={e => setSearch(e.target.value)} />
        <select style={S.select} value={branch} onChange={e => setBranch(e.target.value)}>
          {BRANCHES.map(b => <option key={b}>{b}</option>)}
        </select>
      </div>

      {filtered.length === 0 ? (
        <p style={{ color: C.gray500, textAlign: 'center', padding: '2rem' }}>No veterans match your search.</p>
      ) : (
        <div style={S.grid}>
          {filtered.map(v => {
            const [bg, fg] = statusColor(v.status);
            return (
              <div key={v.id} style={S.card}>
                <div style={{ fontSize: '2.5rem', color: C.accent, marginBottom: '0.5rem' }}>👤</div>
                <div style={S.cardTitle}>{v.name}</div>
                <div style={S.cardSub}>{v.program}</div>
                <div style={S.cardMeta}>🎖 {v.branch}</div>
                <span style={S.pill(bg, fg)}>{v.status}</span>
              </div>
            );
          })}
        </div>
      )}
      <p style={{ color: C.gray500, fontSize: '0.82rem', marginTop: '1rem' }}>
        Showing {filtered.length} of {MOCK_VETERANS.length} veterans
      </p>
    </div>
  );
};

const EmployersPage = () => (
  <div style={S.container}>
    <h2 style={S.sectionH}>Partner Employers</h2>
    <p style={S.sectionSub}>Companies actively hiring from the WAVets2Tech program</p>
    <div style={S.grid}>
      {MOCK_COMPANIES.map(c => (
        <div key={c.id} style={S.card}>
          <div style={{ fontSize: '2rem', color: C.accent, marginBottom: '0.5rem' }}>🏢</div>
          <div style={S.cardTitle}>{c.companyName}</div>
          <div style={S.cardMeta}>✉ {c.email}</div>
          <div style={S.cardMeta}>📞 {c.phone}</div>
          <span style={S.pill()}>Partner</span>
        </div>
      ))}
    </div>
    <p style={{ color: C.gray500, fontSize: '0.82rem', marginTop: '1rem' }}>
      {MOCK_COMPANIES.length} partner employer(s) listed
    </p>
  </div>
);

// ── Root App ────────────────────────────────────────────────────
const App = () => {
  const [page, setPage] = useState('home');

  const navItems = [
    { key: 'home',      label: 'Home'      },
    { key: 'jobs',      label: 'Jobs'      },
    { key: 'veterans',  label: 'Veterans'  },
    { key: 'employers', label: 'Employers' },
  ];

  return (
    <div style={S.page}>
      {/* ── Navbar ─────────────────────────────────────────── */}
      <nav style={S.navbar}>
        <h1 style={S.brand} onClick={() => setPage('home')}>
          WAVets<span style={{ color: '#c8102e' }}>2Tech</span>
        </h1>
        <ul style={S.navList}>
          {navItems.map(n => (
            <li key={n.key}>
              <button style={S.navBtn(page === n.key)} onClick={() => setPage(n.key)}>
                {n.label}
              </button>
            </li>
          ))}
        </ul>
      </nav>

      {/* ── Active Page ─────────────────────────────────────── */}
      {page === 'home'      && <HomePage onNavigate={setPage} totalJobs={MOCK_JOBS.length} totalVets={MOCK_VETERANS.length} totalCompanies={MOCK_COMPANIES.length} />}
      {page === 'jobs'      && <JobsPage />}
      {page === 'veterans'  && <VeteransPage />}
      {page === 'employers' && <EmployersPage />}

      {/* ── Footer ──────────────────────────────────────────── */}
      <footer style={S.footer}>
        <p style={{ margin: 0, color: 'rgba(255,255,255,0.5)' }}>
          &copy; {new Date().getFullYear()} WAVets2Tech — A Saint Martin's University Program
        </p>
      </footer>
    </div>
  );
};

export default App;
