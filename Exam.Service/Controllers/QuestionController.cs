using Exam.Business;
using Exam.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Exam.Service.Controllers
{
    [EnableCors("*","*","*")]
    public class QuestionController : ApiController
    {
        private IExamProcessor examProcessor;
        public QuestionController(IExamProcessor examProcessor)
        {
            this.examProcessor = examProcessor;
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var response = await examProcessor.GetQuestion(id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        public async Task<IHttpActionResult> Post([FromBody]QuestionRequest question)
        {
            if(question == null)
                return InternalServerError();

            var response = await examProcessor.SaveQuestion(question);
            if (response == 0)
            {
                return InternalServerError();
            }
            return Ok(response);
        }

        [Route("api/Question/Comment")]
        public async Task<IHttpActionResult> PostQuestionComment([FromBody]QuestionCommentRequest questionComment)
        {
            var response = await examProcessor.SaveQuestionComment(questionComment);
            if (response == 0)
            {
                return InternalServerError();
            }
            return Ok(response);
        }

        [Route("api/Question/Attempt/{Id}/AttemptDetail")]
        public async Task<IHttpActionResult> PostUserAttempt([FromBody]AttemptDetailRequest attemptDetail)
        {
            var response = await examProcessor.SaveAttemptDetail(attemptDetail);
            if (response == 0)
            {
                return InternalServerError();
            }
            return Ok(response);
        }

        [Route("api/Question/Attempt")]
        public async Task<IHttpActionResult> PostAttempt([FromBody]AttemptRequest attempt)
        {
            var response = await examProcessor.StartAttempt(attempt);
            if (response == 0)
            {
                return InternalServerError();
            }
            return Ok(response);
        }

        [Route("api/Question/Attempt")]
        public async Task<IHttpActionResult> PutAttempt([FromBody]AttemptRequest attempt)
        {
            var response = await examProcessor.EndAttempt(attempt);
            if (response == 0)
            {
                return InternalServerError();
            }
            return Ok(response);
        }


        [Route("api/Question/Vote")]
        public async Task<IHttpActionResult> PostUserAttempt([FromBody]QuestionVoteRequest questionVote)
        {
            var response = await examProcessor.SaveQuestionVote(questionVote);
            if (response == 0)
            {
                return InternalServerError();
            }
            return Ok(response);
        }


    }
}
